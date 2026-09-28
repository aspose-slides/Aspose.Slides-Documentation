---
title: 展開と有効化
type: docs
weight: 20
url: /ja/sharepoint/deployment-and-activation/
description: "展開時に Aspose.Slides for SharePoint ソリューションがファームにインストールするもの、および有効化時にサイトコレクション機能が追加するもの。"
---
## **展開**

展開時に、Aspose.Slides for SharePoint ソリューションは:

- アセンブリをグローバル アセンブリ キャッシュにインストールし、**web.config** ファイルに SafeControl エントリを追加します。SharePoint 2010 以降では、*Aspose.Slides.SharePoint2010.dll*、*Aspose.Slides.SharePoint2013.dll*、または *Aspose.Slides.SharePoint2016.dll*（SharePoint 2019 パッケージでも *Aspose.Slides.SharePoint2016.dll* がインストールされます）。SharePoint 2007 では、*Aspose.Slides.SharePointUI.dll* と *Aspose.Slides.SharePoint.Deployment.dll* が使用されます。
- 変換ページとその画像およびその他のサポート ファイルを SharePoint のインストール フォルダーにコピーします。
- 機能をインストールし、サイト コレクションで有効化できるようにします。

## **有効化**

Aspose.Slides for SharePoint はサイト コレクションの機能としてパッケージ化されており、サイト コレクションで有効化または無効化できます。有効化されると、機能は次を追加します:

- SharePoint 2010 以降:
  - ドキュメント ライブラリのドキュメント メニューに **Convert via Aspose.Slides** 項目を追加;
  - **Convert Slides** ボタンを含む **Aspose Tools** リボン タブを追加し、選択したドキュメントを変換;
  - PPT、PPTX、PPS、PPSX ファイルのメニューに **View Slides** 項目を追加。
- SharePoint 2007:
  - ドキュメント ライブラリのドキュメント メニューに **Convert with Aspose.Slides** 項目を追加;
  - ドキュメント ライブラリの **Actions** メニューに **Convert All with Aspose.Slides** 項目を追加。

SharePoint 2007 では、有効化に伴いサイト コレクションの親 Web アプリケーションの仮想ディレクトリにも変更が加えられます。これにより:

- 変換設定ページがサイトマップ ファイルに追加されます。
- 必要なリソース ファイルが仮想ディレクトリの App_GlobalResources フォルダーにコピーされます。

セットアップ プログラムは、[installation](/slides/ja/sharepoint/installing-aspose-slides-for-sharepoint/) 中に選択したサイト コレクションで機能を有効化します。