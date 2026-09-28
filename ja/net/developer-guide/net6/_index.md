---
title: .NET 6 以降向けクロスプラットフォーム パッケージ
linktitle: クロスプラットフォーム パッケージ
type: docs
weight: 235
url: /ja/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- クロスプラットフォーム
- .NET 6 サポート
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides.NET6.CrossPlatform パッケージの使用タイミングを学びます: なぜ存在するのか、対応プラットフォーム、Linux で libgdiplus の代わりに必要なもの"
---
## **はじめに**

Aspose.Slides for .NET は2つの NuGet パッケージとして提供されています。[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) は Microsoft の System.Drawing.Common ライブラリを使用してスライドを描画します。[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) は代わりに独自のグラフィックエンジンで描画します。本記事では、2 番目のパッケージが存在する理由、実行環境、Linux で必要なもの、そして System.Drawing.Common と同一プロジェクトで併用する方法について説明します。

## **別パッケージが必要な理由**

.NET 6 以降、Microsoft は System.Drawing.Common を [Windows のみでサポート](/slides/ja/net/system-requirements/) としています。その結果、Linux 上では Aspose.Slides.NET は `libgdiplus` ライブラリに加えて `System.Drawing.EnableUnixSupport` スイッチが必要となり、プロジェクトが System.Drawing.Common 7 以降を参照している場合は失敗します。[System Requirements](/slides/ja/net/system-requirements/) でこれらの条件が説明されています。

Aspose.Slides.NET6.CrossPlatform は System.Drawing.Common も `libgdiplus` も使用しません。そのグラフィックエンジンは、パッケージが各対応プラットフォーム用に 1 つずつ含むネイティブライブラリです。両パッケージは同じ Aspose.Slides 名前空間とクラスを提供するため、切り替えても変更が必要なのはパッケージ参照だけで、コードはそのままです。

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Graphics | System.Drawing.Common | パッケージに含まれるネイティブ グラフィックエンジン |
| Target frameworks | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Linux requirements | `libgdiplus` と `System.Drawing.EnableUnixSupport` スイッチ | `fontconfig` |
| Alpine Linux | サポート | 未サポート |

## **サポートされているプラットフォーム**

Aspose.Slides.NET6.CrossPlatform は .NET 6 以降のバージョンで、以下のプラットフォームで動作します。

- **Windows**: x86 と x64。ネイティブライブラリは Microsoft Visual C++ ランタイムを使用します。詳しくは [System Requirements](/slides/ja/net/system-requirements/) を参照してください。
- **Linux**: glibc 2.23 以降を使用した x64、および glibc 2.39 以降を使用した ARM64。
- **macOS**: x64 (Intel) と ARM64 (Apple silicon)。

Windows の ARM64、Alpine Linux や musl を使用したその他のディストリビューション、あるいは CentOS 7 のように古い glibc を使用しているディストリビューションでは実行できません。そのようなシステムでは Aspose.Slides.NET を使用してください。

## **Linux でのインストール**

Linux では、このパッケージは `fontconfig` ライブラリが必要で、`libgdiplus` は必要ありません。Debian および Ubuntu では、`fontconfig` をインストールし、次にパッケージをプロジェクトに追加します。

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Debian および Ubuntu では、`libfontconfig1` が DejaVu フォントもインストールするため、追加のフォントパッケージなしでテキストが表示されます。`fontconfig` がない状態で [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) を作成しようとすると、`TypeInitializationException` が発生し、内部の `DllNotFoundException` が `libfontconfig.so.1` を開けないことを報告します。[System Requirements](/slides/ja/net/system-requirements/) にはセットアップを確認する簡単なプログラムが含まれています。

## **クラウドおよびコンテナホスト**

`libgdiplus` が不要なため、Linux ホストで `libgdiplus` をインストールできない環境では Aspose.Slides.NET6.CrossPlatform を使用します。ただし、`fontconfig` とフォントは必要で、ミニマルなベースイメージには含まれていないことがあります。たとえば .NET 8 用の AWS Lambda ベースイメージにはどちらも含まれていません。そのイメージを基にしたコンテナで、`dnf install -y fontconfig` を実行すると、Noto Sans フォントもインストールされます。

特定のクラウドプラットフォーム向けのガイドは、[Aspose.Slides on Cloud Platforms](/slides/ja/net/slides-on-cloud-platforms/) をご参照ください。

## **同一プロジェクトで System.Drawing.Common を使用する (CS0433)**

Aspose.Slides.NET6.CrossPlatform を使用するプロジェクトは、System.Drawing.Common を直接または他のパッケージ経由で参照できます。現在の Aspose.Slides のバージョンでは `System` 名前空間に公開型がないため、両ライブラリは競合せず、同一ファイルで `Aspose.Slides` と `System.Drawing` 名前空間をインポート可能です。

コンパイラが CS0433 エラーを出し、`Image` や `Graphics` などの型が Aspose.Slides と System.Drawing.Common の両方に存在する場合、プロジェクトは古いバージョンの Aspose.Slides を使用しています。パッケージを最新バージョンに更新してください。Aspose.Slides は描画された画像を [IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) オブジェクトとして返します。この詳細は [Modern API](/slides/ja/net/modern-api/) に記載されています。

## **FAQ**

**Aspose.Slides.NET から Aspose.Slides.NET6.CrossPlatform に切り替える際、コードを変更する必要がありますか？**

いいえ。両パッケージは同じ Aspose.Slides 名前空間とクラスを提供するため、パッケージ参照を差し替えるだけで済みます。Aspose.Slides.NET6.CrossPlatform は `System.Drawing.EnableUnixSupport` スイッチを必要としません。プロジェクトにはどちらか一方のパッケージだけを追加してください。

**.NET Framework プロジェクトで Aspose.Slides.NET6.CrossPlatform を使用できますか？**

いいえ。このパッケージは .NET 6 以降のみを対象としています。.NET Framework 4.6.2 以降を使用する場合は Aspose.Slides.NET を使用してください。