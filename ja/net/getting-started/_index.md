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
description: "新しい .NET プロジェクトから Aspose.Slides を使用した最初の保存済みプレゼンテーションまでの手順: 要件を確認し、パッケージをインストールし、最初のプログラムを実行し、共通タスクを続けます。"
---
## **概要**

以下の4つの手順を順番に実行してください。各手順はやるべきことを示し、詳細記事へのリンクがあります。評価、ライセンス、サポートについては手順の後で説明します。

## **ステップ 1: システム要件の確認**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) は Windows、Linux、macOS で動作します。[システム要件](/slides/ja/net/system-requirements/) は各パッケージがサポートするオペレーティングシステムと .NET バージョン、そして Linux が追加で必要とするライブラリを一覧表示しています。

## **ステップ 2: パッケージのインストール**

Aspose.Slides for .NET は NuGet を通じて 2 つのパッケージとして配布されており、同じクラスを提供します。プロジェクトにそのうちの 1 つを追加します:

- Windows の場合: `dotnet add package Aspose.Slides.NET`
- Linux と macOS の場合: `dotnet add package Aspose.Slides.NET6.CrossPlatform`。Linux では、先に `fontconfig` ライブラリをインストールしてください。
- Alpine Linux、または glibc が 2.23 (x64) 未満または 2.39 (ARM64) 未満の Linux システムの場合: `Aspose.Slides.NET` を使用し、`libgdiplus` ライブラリをインストールしてください。

[インストール](/slides/ja/net/installation/) は Linux のコマンド、Aspose.Slides.NET が Linux で必要とする追加の起動設定、そして Visual Studio 用の手順を提供します。

## **ステップ 3: 最初のプレゼンテーションを作成**

[Aspose.Slides for .NET ホームページのクイックスタート](/slides/ja/net/#your-first-presentation) は完全なコンソールプログラムです。スライドにテキスト ボックスを追加し、プレゼンテーションを PPTX ファイルとして保存します。[プレゼンテーションの作成](/slides/ja/net/create-presentation/) は同じ手順を詳しく説明し、既存のプレゼンテーションを開いて別の形式で保存する方法を示します。

## **ステップ 4: 一般的なタスクを続行**

- [プレゼンテーションを開く](/slides/ja/net/open-presentation/)
- [プレゼンテーションを保存](/slides/ja/net/save-presentation/)
- [プレゼンテーションを PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf/)
- [スライドを画像としてレンダリング](/slides/ja/net/convert-slide/)
- [プレゼンテーションのテキストを編集](/slides/ja/net/manage-text/)
- [スライド要素別の例](/slides/ja/net/examples/)

## **評価とライセンス**

ライセンスがない場合、Aspose.Slides は評価モードで動作します。保存するすべてのスライドに透かしが追加され、プレゼンテーションから読み取ったテキストが途中で切り捨てられます。

- [Aspose.Slides の評価](/slides/ja/net/evaluate-aspose-slides/) は評価時の制限事項と一時ライセンスの取得方法を説明します。
- [ライセンス設定](/slides/ja/net/licensing/) はファイル、ストリーム、または埋め込みリソースからライセンスを適用する方法を示します。
- [従量課金ライセンス](/slides/ja/net/metered-licensing/) は使用量に基づいて課金されるライセンスについて説明します。
- [サポートされているファイル形式](/slides/ja/net/supported-file-formats/) は Aspose.Slides が読み込みおよび保存できる形式の一覧です。

## **ヘルプを取得**

[製品サポート](/slides/ja/net/product-support/) は、[無料サポートフォーラム](https://forum.aspose.com/c/slides/11) で質問する方法と、問題を報告する際に含めるべき情報を説明します。

## **よくある質問**

**Microsoft PowerPoint はインストールが必要ですか？**

いいえ。Aspose.Slides はプレゼンテーション ファイルを自ら読み書きし、PowerPoint を使用しないため、サーバーや Linux 上でも実行できます。

**.NET Framework アプリケーションにはどのパッケージを使用すべきですか？**

Aspose.Slides.NETです。.NET Framework 4.6.2 以降、.NET 6 以降、そして .NET Standard 2.0 用のビルドが含まれています。Aspose.Slides.NET6.CrossPlatform は .NET 6 以降が必要です。