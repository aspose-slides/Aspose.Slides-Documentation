---
title: Aspose.Slides for SharePoint のインストール
type: docs
weight: 10
url: /ja/sharepoint/installing-aspose-slides-for-sharepoint/
description: "SharePoint ファームに Aspose.Slides for SharePoint をインストールします。使用している SharePoint バージョンに合わせたセットアップ プログラムを選択し、システム チェックを実行して、ソリューションをデプロイおよび有効化します。"
---
## **パッケージ内容**

Aspose.Slides for SharePoint は [download page](https://releases.aspose.com/slides/sharepoint/) から ZIP アーカイブとしてダウンロードされます。アーカイブにはサポートされている各 SharePoint バージョン用の SharePoint ソリューション パッケージ (WSP) とセットアップ プログラムが 1 つずつ含まれています。

| SharePoint version | Setup program | Solution package |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

各セットアップ プログラムの隣には構成ファイル (例: *Setup2019.exe.config*) があり、インストールするソリューション パッケージの名称が記載されています。*License* フォルダーにはエンドユーザー ライセンス契約書へのリンクとサードパーティ ライセンス通知が格納されています。

Aspose.Slides for SharePoint は SharePoint ソリューションとしてパッケージ化され、SharePoint がサーバー ファーム全体にデプロイします。機能はサイト コレクションごとに有効化または無効化されます。

## **インストール手順**

インストール前に、セットアップ プログラムはシステム チェックを実行します。チェック内容は次のとおりです。

- サーバーに SharePoint がインストールされていること
- 現在のユーザーに SharePoint ソリューションのインストールおよびデプロイ権限があること
- SharePoint 管理サービスが起動していること
- SharePoint タイマー サービスが起動していること
- 構成ファイルに記載されたソリューション パッケージが存在すること

管理サービスとタイマー サービスは、いくつかのセットアップ アクションがタイマー ジョブとして実行され、ファーム内のすべてのサーバーにソリューションを伝搬させるために必要です。

### **インストールの実行**

Aspose.Slides for SharePoint をインストールする手順:

1. ZIP アーカイブを SharePoint ファーム内のサーバーのローカル ドライブに展開します。
2. ご使用の SharePoint バージョンに一致するセットアップ プログラムを実行し、画面の指示に従います。セットアップ プログラムは次の手順を行います:
   1. システム チェックを実行します。チェックに失敗した場合は続行しません。

      **システム チェックの実行**

      ![セットアップ プログラムのシステム チェック画面](installing-aspose-slides-for-sharepoint_1.png)

   2. エンドユーザー ライセンス契約書を表示します。続行するには同意が必要です。

      **ライセンス契約書**

      ![セットアップ プログラムのライセンス契約画面](installing-aspose-slides-for-sharepoint_2.png)

   3. デプロイ先を表示します。機能を有効化する Web アプリケーションとサイト コレクションを選択します。

      **デプロイ先の選択**

      ![セットアップ プログラムのサイト コレクション デプロイ先画面](installing-aspose-slides-for-sharepoint_3.png)

   4. ソリューションをファームにデプロイします。

      **インストールの進行状況**

      ![セットアップ プログラムのインストール進行画面](installing-aspose-slides-for-sharepoint_4.png)

   5. 選択したサイト コレクションで Aspose.Slides for SharePoint を有効化します。
   6. ソリューションがデプロイおよび有効化された Web アプリケーションとサイト コレクションの一覧を表示します。

      **インストールの成功**

      ![セットアップ プログラムのインストール完了画面](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
スクリーンショットは SharePoint 2007 で取得しています。後続バージョンのセットアップ プログラムも同じ画面が表示されます。
{{% /alert %}}

同じバージョンの Aspose.Slides for SharePoint がすでにインストールされている場合、セットアップ プログラムは修復または削除を提案します。別バージョンがインストールされている場合は、アップグレードまたは削除を提案します。

インストール後、選択したサイト コレクションのドキュメント ライブラリのファイル メニューに **Convert via Aspose.Slides** 項目が表示されます (SharePoint 2007 では **Convert with Aspose.Slides**)。最初のプレゼンテーションを変換する方法は [Converting Microsoft PowerPoint Documents into Other Formats](/slides/ja/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/) を参照してください。ファームに追加されるソリューションの詳細は [Deployment and Activation](/slides/ja/sharepoint/deployment-and-activation/) に記載されています。

## **よくある質問**

**どのセットアップ プログラムを実行すればよいですか？**

ご使用の SharePoint バージョンと名前が一致するものです。例: SharePoint Server 2016 ファームでは *Setup2016.exe* を実行します。各セットアップ プログラムは自分のソリューション パッケージのみをインストールします。

**ライセンス版用に別途ダウンロードが必要ですか？**

いいえ。同じパッケージは評価モードで動作し、ライセンス ソリューションをインストールすると正規版になります。詳細は [Installing Aspose.Slides for SharePoint License](/slides/ja/sharepoint/installing-aspose-slides-for-sharepoint-license/) を参照してください。

**製品をアンインストールするには？**

同じセットアップ プログラムを再度実行し、**Remove** を選択します。手順は [Uninstalling Aspose.Slides for SharePoint](/slides/ja/sharepoint/uninstalling-aspose-slides-for-sharepoint/) をご覧ください。