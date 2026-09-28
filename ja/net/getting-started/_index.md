---
title: はじめに
type: docs
weight: 10
url: /ja/net/getting-started/
keywords:
- はじめに
- システム要件
- インストール
- 最初のプレゼンテーション
- NuGet
- PPT 処理
- PPTX 処理
- ODP 処理
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "新しい .NET プロジェクトから Aspose.Slides を使用した最初の保存済みプレゼンテーションまでの流れです。要件を確認し、パッケージをインストールし、最初のプログラムを実行し、共通タスクを続けます。"
---
## **概要**

以下の 4 つの手順を順番に実行してください。各手順は実行内容を示し、詳細記事へのリンクがあります。評価、ライセンス、サポートは手順の後に記載しています。

## **ステップ 1: システム要件の確認**

Aspose.Slides for .NET は Windows、Linux、macOS で動作します。[System Requirements](/slides/ja/net/system-requirements/) では、各パッケージがサポートするオペレーティングシステムと .NET バージョン、そして Linux が追加で必要とするライブラリが一覧になっています。

## **ステップ 2: パッケージのインストール**

Aspose.Slides for .NET は NuGet を通じて同等のクラスを提供する 2 つのパッケージとして配布されています。そのうちの 1 つをプロジェクトに追加してください。

- Windows の場合: `dotnet add package Aspose.Slides.NET`
- Linux と macOS の場合: `dotnet add package Aspose.Slides.NET6.CrossPlatform`。Linux では先に `fontconfig` ライブラリをインストールしてください。
- Alpine Linux、または glibc が 2.23 未満 (x64) または 2.39 未満 (ARM64) の Linux システムの場合: `Aspose.Slides.NET` を使用し、`libgdiplus` ライブラリをインストールしてください。

[Installation](/slides/ja/net/installation/) では、Linux 用コマンド、Aspose.Slides.NET が Linux で必要とする追加の起動設定、Visual Studio 用の手順が掲載されています。

## **ステップ 3: 最初のプレゼンテーションを作成する**

[Aspose.Slides for .NET のホームページにあるクイックスタート](/slides/ja/net/#your-first-presentation) は完全なコンソールプログラムです。スライドにテキストボックスを追加し、プレゼンテーションを PPTX ファイルとして保存します。[Create Presentations](/slides/ja/net/create-presentation/) では同じ手順を詳しく解説し、既存のプレゼンテーションを開いて別の形式で保存する方法も示しています。

## **ステップ 4: 共通タスクを続行する**

- [プレゼンテーションを開く](/slides/ja/net/open-presentation/)
- [プレゼンテーションを保存する](/slides/ja/net/save-presentation/)
- [プレゼンテーションを PDF に変換する](/slides/ja/net/convert-powerpoint-to-pdf/)
- [スライドを画像としてレンダリングする](/slides/ja/net/convert-slide/)
- [プレゼンテーションのテキストを編集する](/slides/ja/net/manage-text/)
- [スライド要素別の例](/slides/ja/net/examples/)

## **評価とライセンス**

ライセンスなしで使用すると、Aspose.Slides は評価モードになり、保存するすべてのスライドに透かしが付加され、プレゼンテーションから読み取ったテキストが切り詰められます。

- [Evaluate Aspose.Slides](/slides/ja/net/evaluate-aspose-slides/) では評価版の制限と一時ライセンスの取得方法を説明しています。
- [ライセンス認証](/slides/ja/net/licensing/) ではファイル、ストリーム、埋め込みリソースからライセンスを適用する方法を示しています。
- [従量課金ライセンス](/slides/ja/net/metered-licensing/) では使用量に応じて課金されるライセンスモデルを取り上げています。
- [対応ファイル形式](/slides/ja/net/supported-file-formats/) では Aspose.Slides が読み書きできる形式を一覧化しています。

## **サポートを受ける**

[製品サポート](/slides/ja/net/product-support/) では、[無料サポートフォーラム](https://forum.aspose.com/c/slides/11) で質問する方法と、問題を報告する際に含めるべき情報について説明しています。

## **FAQ**

**Microsoft PowerPoint をインストールする必要がありますか？**

いいえ。Aspose.Slides はプレゼンテーションファイルを自前で読み書きするため PowerPoint を使用せず、サーバーや Linux 上でも動作します。

**.NET Framework アプリケーションにはどのパッケージを使用すべきですか？**

Aspose.Slides.NET を使用してください。これは .NET Framework 4.6.2 以降、.NET 6 以降、.NET Standard 2.0 用のビルドを含みます。Aspose.Slides.NET6.CrossPlatform は .NET 6 以降が必要です。