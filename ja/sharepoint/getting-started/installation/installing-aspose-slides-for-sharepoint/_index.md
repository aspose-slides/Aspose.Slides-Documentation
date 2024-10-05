---
title: Aspose.Slides for SharePointのインストール
type: docs
weight: 10
url: /sharepoint/installing-aspose-slides-for-sharepoint/
---

{{% alert color="primary" %}} 

Aspose.Slides for SharePointは、Aspose.Slides.SharePoint.zipアーカイブとしてダウンロードされます。このアーカイブには以下が含まれています：

- **Aspose.Slides.SharePoint.wsp**: SharePointソリューションファイル。Aspose.Slides for SharePointはSharePointソリューションとしてパッケージ化されており、サーバーファーム全体でのアクティベーションと非アクティベーションを容易にします。
- **Aspose_LicenseAgreement.rtf**: エンドユーザーライセンス契約。
- **Setup.exe**: セットアッププログラム。
- **Setup.exe.config**: セットアップ構成ファイル。

{{% /alert %}} 
## **インストールプロセス**
インストールを実行する前に、セットアッププログラムは以下を確認します：

- WSS 3.0またはMOSS 2007がインストールされていること。
- ユーザーにSharePointソリューションをインストールする権限があること。
- SharePointデータベースがオンラインであること。
- WSS管理サービスが起動していること。
- WSSタイマーサービスが起動していること。

WSS管理サービスとタイマーサービスは必要です。なぜなら、いくつかのセットアップアクションは、サーバーファーム内のすべてのサーバーに展開するためのタイマージョブに依存しているからです。 
### **インストールの実行**
Aspose.Slides for SharePointをインストールするには：

1. Aspose.Slides.SharePoint zipをMOSS 7.0またはWSS 3.0サーバーのローカルドライブに解凍します。
2. setup.exeを実行し、画面の指示に従います。
   セットアッププログラムは以下のアクションを実行します：
   1. インストールの前提条件を確認します。チェックのいずれかが失敗した場合、セットアップは続行されません。

      **システムチェックの実行** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. エンドユーザーライセンス契約を表示します。契約を受け入れる必要があります。

   **EULA** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. デプロイ先の選択を表示します。機能をアクティベートすべきWebアプリケーションとサイトコレクションを選択します。

   **デプロイ先の選択** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. サーバーファームに機能をデプロイします。

   **インストール進捗バー** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. 選択されたサイトコレクションのAspose.Slidesをアクティブ化し、その親Webアプリケーションを構成します。
7. 機能がデプロイされアクティブ化されたWebアプリケーションとサイトコレクションの一覧を表示します。

   **成功したインストール** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)
```