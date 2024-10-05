---
title: レポートサービスの設定
type: docs
weight: 30
url: /reportingservices/setting-up-reporting-services/
---

{{% alert color="primary" %}} 

RSサーバーでの最初のステップは、レポートサービス構成マネージャーです。 

{{% /alert %}} 
## **サービスアカウント**
レポートサービスで使用しているサービスアカウントを理解しておくことが重要です。問題が発生した場合、それは使用しているサービスアカウントに関連している可能性があります。デフォルトはネットワークサービスです。新しいビルドをデプロイする際は、常にドメインアカウントを使用します。そこに問題が発生する可能性が高いからです。このサーバーの設定では、**RSService**というドメインアカウントを使用しました。 
## **WebサービスURL**
WebサービスURLを構成する必要があります。これは、Webサービスがホストされる**ReportServer**仮想ディレクトリ（vdir）であり、SharePointとの通信に使用されます。vdirのプロパティをカスタマイズしたい場合（つまり、SSL、ポート、ホストヘッダーなど）、ここで適用をクリックすれば良いでしょう。 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)


**図3**: WebサービスURLの設定 

完了すると、以下の図が表示されます。 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**図4**: WebサービスURLの設定が成功しました 
## **データベース**
レポートサービスカタログデータベースを作成する必要があります。これは、SQL 2008またはSQL 2008 R2データベースエンジンのいずれかに配置できます。SQL11も問題ありませんが、まだBETA版です。この操作により、デフォルトで**ReportServer**と**ReportServerTempDB**の2つのデータベースが作成されます。
この重要なステップは、データベースタイプとしてSharePoint統合を選択することを確認することです。この選択は、一度行うと変更できません。参照用に図5、6、7をご覧ください。 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**図5**: レポートサーバーデータベースの作成 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**図6**: データベースサーバーと認証タイプの設定 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**図7**: データベース名とモードの設定 

資格情報については、これがレポートサーバーがSQLサーバーと通信する方法です。選択するアカウントには、カタログデータベース内およびRSExecRoleを介していくつかのシステムデータベースに特定の権限が与えられます。MSDBは、SQLエージェントを使用するためのサブスクリプション利用に関連するデータベースの一つです。 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**図8**: レポートサーバーデータベースの資格情報の設定 

完了すると、次の図のようになります。 

![todo:image_alt_text](setting-up-reporting-services_8.png)


**図9**: レポートサーバーデータベース設定の進行状況 
## **レポートマネージャーURL**
レポートマネージャーURLは、SharePoint統合モードのときは使用されないため、スキップできます。SharePointがフロントエンドです。レポートマネージャーは機能しません。 
## **暗号化キー**
暗号化キーをバックアップし、それを保管している場所を確認してください。データベースの移行や復元が必要な場合、これが必要です。 

![todo:image_alt_text](setting-up-reporting-services_9.png)

これでレポートサービス構成マネージャーの設定は完了です。WebサービスURLタブのURLにアクセスすると、以下の図に似たものが表示されるはずです。 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**図12**: インストール後のレポートサーバーへのアクセス 

何が起こりましたか？私のWFEにSharePointがインストールされ、レポートサービスの設定が完了しました。この例では、レポートサービスとSharePointは異なるマシンにあります。同じマシンにあった場合、このエラーは表示されませんでした。技術的には、RSボックスにSharePointをインストールする必要があります。それはつまり、IISも有効にする必要があるということです。