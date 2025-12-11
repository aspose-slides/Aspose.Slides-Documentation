---
title: C++ でプレゼンテーション スライドをクローンする
linktitle: スライドをクローン
type: docs
weight: 40
url: /ja/cpp/clone-slides/
keywords:
- スライドのクローン
- スライドのコピー
- スライドの保存
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint スライドをすばやく複製します。明確なコード例に従って、数秒で PPT の作成を自動化し、手作業を排除します。"
---

## **プレゼンテーション内のスライドをクローンする**
クローンとは、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides for C++ は、任意のスライドのコピーまたはクローンを作成し、そのクローンしたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することを可能にします。スライドのクローン作成プロセスにより、元のスライドを変更せずに開発者が変更できる新しいスライドが生成されます。スライドをクローンする方法はいくつかあります。

- プレゼンテーション内の末尾にクローンする。
- プレゼンテーション内の別の位置にクローンする。
- 別のプレゼンテーションの末尾にクローンする。
- 別のプレゼンテーションの別の位置にクローンする。
- 別のプレゼンテーションの特定の位置にクローンする。

Aspose.Slides for C++ では、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) オブジェクトが公開する [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) コレクション (スライドのコレクション) が、上記のスライドクローン操作を実行するための [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) および [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) メソッドを提供します。

## **プレゼンテーションの末尾にスライドをクローンする**
同じプレゼンテーションファイル内の既存スライドの末尾にスライドをクローンして使用したい場合は、以下の手順に従って [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) オブジェクトが公開する [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) メソッドを呼び出し、クローン対象のスライドをパラメーターとして渡します。
1. 変更したプレゼンテーションファイルを書き出します。

以下の例では、プレゼンテーションの最初の位置 (0 インデックス) にあるスライドをプレゼンテーションの末尾にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **プレゼンテーション内の別の位置にスライドをクローンする**
同じプレゼンテーションファイル内で別の位置にスライドをクローンして使用したい場合は、[InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. **Slides** コレクションを参照してクラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) オブジェクトが公開する [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメーターとして渡します。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションの 0 インデックス (位置 1) にあるスライドをインデックス 1 (位置 2) にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **別のプレゼンテーションの末尾にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの既存スライドの末尾に追加したい場合は、次の手順を実行します。

1. クローン元のプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. クローン先のプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 目的プレゼンテーションの **Slides** コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) オブジェクトが公開する [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) メソッドを呼び出し、ソースプレゼンテーションからのスライドをパラメーターとして渡します。
1. 変更した目的プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションの最初のインデックスにあるスライドを目的プレゼンテーションの末尾にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **別のプレゼンテーションの別の位置にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの特定の位置に配置したい場合は、次の手順を実行します。

1. ソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 目的プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 目的プレゼンテーションの Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) オブジェクトが公開する [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) メソッドを呼び出し、ソースプレゼンテーションからのスライドと目的位置をパラメーターとして渡します。
1. 変更した目的プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションの 0 インデックスにあるスライドを目的プレゼンテーションのインデックス 1 (位置 2) にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **別のプレゼンテーションの特定の位置にスライドをクローンする**
あるプレゼンテーションからマスタースライド付きのスライドをクローンし、別のプレゼンテーションで使用したい場合は、まずソースプレゼンテーションから目的プレゼンテーションへマスタースライドをクローンする必要があります。その後、マスタースライドを使用してスライドをクローンします。**AddClone(ISlide, IMasterSlide)** は、ソースプレゼンテーションではなく目的プレゼンテーションのマスタースライドを期待します。マスタースライド付きのスライドをクローンする手順は以下の通りです。

1. ソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 目的プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. クローン対象のスライドとそのマスタースライドにアクセスします。
1. 目的プレゼンテーションの [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) オブジェクトが公開する Masters コレクションを参照して、[IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) クラスのインスタンスを作成します。
1. [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) オブジェクトが公開する [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) メソッドを呼び出し、ソース PPTX からクローンするマスターをパラメーターとして渡します。
1. 目的プレゼンテーションの [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) オブジェクトが公開する [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) メソッドを呼び出し、ソースプレゼンテーションからのスライドとマスタースライドをパラメーターとして渡します。
1. 変更した目的プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションの 0 インデックスにあるマスタースライド付きスライドを、ソーススライドのマスターを使用して目的プレゼンテーションの末尾にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **指定セクションの末尾にスライドをクローンする**
同じプレゼンテーション内で別のセクションにスライドをクローンしたい場合は、[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) インターフェイスが公開する **AddClone()** メソッドを使用します。Aspose.Slides for C++ は、最初のセクションからスライドをクローンし、そのクローンしたスライドを同じプレゼンテーションの第二セクションに挿入することを可能にします。

以下のコードスニペットは、スライドをクローンして指定セクションに挿入する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **FAQ**

**スピーカーノートやレビュアーコメントもクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に [削除してください](/slides/ja/cpp/presentation-notes/)。

**チャートとそのデータソースはどのように扱われますか？**

チャートオブジェクト、書式設定、埋め込みデータはコピーされます。チャートが外部ソース (例: OLE 埋め込みブック) にリンクされている場合、そのリンクは [OLE オブジェクト](/slides/ja/cpp/manage-ole/) として保存されます。ファイル間で移動した後は、データの可用性とリフレッシュ動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライドインデックスにクローンを挿入し、選択した [セクション](/slides/ja/cpp/slide-section/) に配置できます。対象セクションが存在しない場合は、先に作成してからスライドを移動してください。