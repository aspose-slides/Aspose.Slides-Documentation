---
title: RSサーバーでのSharePoint設定
type: docs
weight: 40
url: /reportingservices/setting-up-sharepoint-on-the-rs-server/
---

{{% alert color="primary" %}} 

まず、SharePoint WFEで行ったことと同様の手順を行う必要があります。最初に前提条件のインストールを実施し、その後SharePointのセットアップを開始します。 

セットアップでは、サーバーファームを選択し、私のSharePointボックスに合わせて完全インストールを選びます。SharePointのスタンドアロンインストールは望んでいません。 

{{% /alert %}} 
### **SharePoint構成**
SharePoint構成ウィザードでは、既存のファームに接続したいと思います。 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**図13**: SharePoint構成ウィザード 

次に、私たちのファームが使用している**SharePoint_Config**データベースを指し示します。これがどこにあるかわからない場合は、Central Adminの**システム設定 -> このファームのサーバーを管理**から確認できます。 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**図14**: SharePoint構成ウィザード 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**図15**: SharePoint構成ウィザード 

ウィザードが完了したら、現時点でReport Serverボックスで行う必要があることはすべて終了です。ReportServerのURLに戻ると、別のエラーが表示されますが、それはCentral Administratorを通じて構成していないためです。 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**図16**: レポートサーバーエラー