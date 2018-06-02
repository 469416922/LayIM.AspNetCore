truncate table layim_big_group
truncate table layim_chat_record
truncate table layim_friend_group
truncate table layim_friend_relation
truncate table layim_group_member
truncate table layim_user

--user
insert into layim_user (id,name,avatar,[sign]) values (10001,'С����','/images/photo/xiaopanzi.jpg','LayIM.AspNetCore������')
insert into layim_user (id,name,avatar,[sign]) values (10002,'����','/images/photo/huafei.jpg','���˾�������')

insert into layim_user (id,name,avatar,[sign]) values (10003,'�ʺ�','/images/photo/huanghou.jpg','���������������')
insert into layim_user (id,name,avatar,[sign]) values (10004,'����','/images/photo/huangshang.jpg','ǰ�����·�æ����Ҳ���ð���')

insert into layim_user (id,name,avatar,[sign]) values (10005,'�Ľ��','/images/photo/meijiejie.jpg','���ϣ����ԩ������û�м�������')
insert into layim_user (id,name,avatar,[sign]) values (10006,'������','/images/photo/xiaoniao.jpg','���ҳ���õ��˶�����')

insert into layim_user (id,name,avatar,[sign]) values (10007,'����','/images/photo/gonggong.jpg','����ū�ŵ�����')
insert into layim_user (id,name,avatar,[sign]) values (10008,'���','/images/photo/zhenhuan.jpg','�Ǻ�')

--���ѷ���
insert into layim_friend_group (id,name,create_by) values (1000101,'�ҵĺ���',10001)
insert into layim_friend_group (id,name,create_by) values (1000102,'����ͬѧ',10001)
insert into layim_friend_group (id,name,create_by) values (1000103,'��ѧͬѧ',10001)
insert into layim_friend_group (id,name,create_by) values (1000104,'���Է���',10001)
insert into layim_friend_group (id,name,create_by) values (1000105,'���Է���',10001)
insert into layim_friend_group (id,name,create_by) values (1000106,'���Է���',10001)
insert into layim_friend_group (id,name,create_by) values (1000107,'���Է���',10001)
insert into layim_friend_group (id,name,create_by) values (1000108,'���Է���',10001)
insert into layim_friend_group (id,name,create_by) values (1000109,'���Է���',10001)
insert into layim_friend_group (id,name,create_by) values (1000110,'���Է���',10001)
insert into layim_friend_group (id,name,create_by) values (1000111,'���Է���',10001)

insert into layim_friend_group (id,name,create_by) values (1000201,'�ҵĺ���',10002)
insert into layim_friend_group (id,name,create_by) values (1000202,'�󹬵���',10002)

--���ѹ�ϵ
insert into layim_friend_relation (uid1,uid2,friend_group_1,friend_group_2) values (10001,10002,1000101,1000201)
insert into layim_friend_relation (uid1,uid2,friend_group_1,friend_group_2) values (10001,10003,1000101,0)
insert into layim_friend_relation (uid1,uid2,friend_group_1,friend_group_2) values (10001,10004,1000101,0)
insert into layim_friend_relation (uid1,uid2,friend_group_1,friend_group_2) values (10001,10005,1000101,0)
insert into layim_friend_relation (uid1,uid2,friend_group_1,friend_group_2) values (10001,10006,1000101,0)
insert into layim_friend_relation (uid1,uid2,friend_group_1,friend_group_2) values (10001,10007,1000101,0)
insert into layim_friend_relation (uid1,uid2,friend_group_1,friend_group_2) values (10001,10008,1000101,0)

--Ⱥ��

insert into layim_big_group values ('�����Ժ','/images/photo/huangzu.jpg',10001)

insert into layim_group_member values (1,10001,0)
insert into layim_group_member values (1,10002,0)
insert into layim_group_member values (1,10003,0)
insert into layim_group_member values (1,10004,0)
insert into layim_group_member values (1,10005,0)
insert into layim_group_member values (1,10006,0)
insert into layim_group_member values (1,10007,0)
insert into layim_group_member values (1,10008,0)
