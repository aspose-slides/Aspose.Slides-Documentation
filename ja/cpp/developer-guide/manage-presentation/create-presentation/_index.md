---
title: プレゼンテーションの作成 - C++ PowerPoint API
linktitle: プレゼンテーションの作成
type: docs
weight: 10
url: /cpp/create-presentation/
description: C++ APIでPowerPointプレゼンテーションを作成するには、本記事に記載されている手順に従ってください。コードはプレゼンテーションの最初のスライドにラインを追加します。
---

## **PowerPointプレゼンテーションの作成**
選択したスライドにシンプルなラインを追加するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Shapesオブジェクトが公開するAddAutoShapeメソッドを使用して、ラインタイプのAutoShapeを追加します。
1. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションの最初のスライドにラインを追加しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}