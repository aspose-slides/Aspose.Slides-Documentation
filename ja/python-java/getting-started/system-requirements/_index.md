---
title: システム要件
type: docs
weight: 60
url: /ja/python-java/system-requirements/
keywords:
- システム要件
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Windows、Linux、macOS 上で Aspose.Slides for Python via Java を実行するためのオペレーティングシステム、Python、Java、JPype の要件を確認してください。"
---
## **概要**

Aspose.Slides for Python via Java は、Microsoft PowerPoint をインストールせずにプレゼンテーションの作成、変更、変換、レンダリングを行います。JPype を使用して Python から Java ライブラリにアクセスするため、環境は Python、Java、JPype を同時にサポートしている必要があります。

## **サポートされているオペレーティングシステム**

以下のオペレーティングシステム ファミリが [Aspose.Slides パッケージ](https://pypi.org/project/aspose-slides-java/) によってサポートされています:

- Windows
- Linux
- macOS

選択した Python、Java、JPype のリリースがサポートするオペレーティングシステム バージョンを選んでください。Java が利用可能であるだけでは、Python パッケージおよびそのブリッジとの互換性が確立されるわけではありません。

## **Python、Java、JPype の要件**

| コンポーネント | 要件 |
| --- | --- |
| Python | Aspose.Slides パッケージは Python 3.7 から 3.14 をサポートすると宣言しています。選択した JPype のリリースは同じ Python バージョンをサポートしている必要があります。例えば、[JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) は Python 3.8 以降が必要です。 |
| Java | 選択した JPype のリリースと互換性のある Java ランタイムまたは JDK をインストールしてください。現在の[JPype 前提条件](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites)は Java 11 以降を指定しています。Java 8 では JPype1 1.7.1 を実行できません。 |
| JPype | 使用している Python インタープリター、オペレーティングシステム、CPU アーキテクチャに対応した JPype1 パッケージをインストールしてください。 |
| CPU アーキテクチャ | Python と Java 仮想マシン (JVM) は同一のアーキテクチャを使用する必要があります。例えば、64 ビットの Python インタープリターは互換性のある 64 ビット JVM が必要です。 |

Apple Silicon では、Python と Java の両方が ARM64 もしくは x64 を使用しなければなりません。独立して実行する JVM でも、アーキテクチャが Python と異なる場合、JPype 経由でロードに失敗することがあります。

新しい環境では、Python 3.12、JDK 17、JPype1 1.7.1 の組み合わせが適切な出発点となります。この構成は Windows 上の Aspose.Slides for Python via Java 26.6.0 で検証されています。他の組み合わせを使用する場合は、3 つのコンポーネントすべての要件を満たす必要があります。

環境設定と実働検証例については、[インストール](/slides/ja/python-java/installation/) を参照してください。

## **追加の依存関係**

互換性のある事前構築済み JPype ホイールを使用すれば C++ コンパイラは不要です。JPype をソースからビルドする必要がある場合は、互換性のある C++ コンパイラとプラットフォームが要求する Python 開発ファイルをインストールしてください。ビルド要件やトラブルシューティングについては、[JPype インストール手順](https://jpype.readthedocs.io/en/latest/install.html) を参照してください。

## **FAQ**

**Microsoft PowerPoint をインストールする必要がありますか？**

いいえ。Aspose.Slides は PowerPoint とは独立してプレゼンテーションを処理します。Python、Java、JPype は依然として必要です。

**Python 3.7 を任意の JPype リリースと組み合わせて使用できますか？**

いいえ。Aspose.Slides パッケージは Python 3.7 のサポートを宣言していますが、JPype1 1.7.1 は Python 3.8 以降が必要です。要件が重なるバージョンを選択してください。

**32 ビット Python と 64 ビット Java を混在させることはできますか？**

いいえ。JPype は JVM を Python プロセスにロードするため、Python と Java は同じアーキテクチャである必要があります。macOS でも ARM64 と x64 について同様の要件が適用されます。