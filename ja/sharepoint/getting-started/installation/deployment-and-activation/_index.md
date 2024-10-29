---
title: デプロイメントとアクティベーション
type: docs
weight: 20
url: /ja/sharepoint/deployment-and-activation/
---

## **デプロイメント**
デプロイメント中、Aspose.Slides for SharePointは：

- **Aspose.Slides.SharePoint.dll**をグローバルアセンブリキャッシュにインストールし、**web.config**ファイルにSafeControlエントリを追加します。
- 特徴マニフェストとその他の必要なファイルを適切なディレクトリにインストールします。
- SharePointデータベースに機能を登録し、機能スコープでのアクティベーションを可能にします。

## **アクティベーション**
Aspose.Slides for SharePointはサイト（サイトコレクション）レベルの機能としてパッケージ化されており、サイトコレクションでアクティベートまたはデアクティベートできます。アクティベーション中、機能はサイトコレクションの親Webアプリケーションの仮想ディレクトリにいくつかの変更を加えます。具体的には：

- サイトマップファイルに変換設定ページを追加します。
- 必要なリソースファイルを仮想ディレクトリのApp_GlobalResourcesフォルダにコピーします。