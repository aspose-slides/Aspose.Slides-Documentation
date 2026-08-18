---
title: C++ でプレゼンテーション スライドをクローン
linktitle: スライドをクローン
type: docs
weight: 40
url: /ja/cpp/clone-slides/
keywords:
- スライドをクローン
- スライドをコピー
- スライドを保存
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint スライドを迅速に複製します。明確なコード例に従って数秒で PPT 作成を自動化し、手作業を排除しましょう。"
---
## **はじめに**

クローン作成は、対象物の正確なコピーまたは複製を作るプロセスです。Aspose.Slides for C++ では、任意のスライドのコピーまたはクローンを作成し、そのクローンされたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することが可能です。スライドのクローン作成により、元のスライドを変更せずに開発者が修正できる新しいスライドが作られます。スライドをクローンする方法はいくつかあります:

- プレゼンテーション内で末尾にクローンする。
- プレゼンテーション内の別の位置にクローンする。
- 別のプレゼンテーションの末尾にクローンする。
- 別のプレゼンテーションの別の位置にクローンする。
- 別のプレゼンテーションの特定の位置にクローンする。

Aspose.Slides for C++ では、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) オブジェクトが公開する([ISlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/) オブジェクトのコレクション) が、上記のスライド クローン作成を実行するための [AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) および [InsertClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/insertclone/) メソッドを提供します。

## **プレゼンテーションの末尾にスライドをクローンする**
既存のスライドの末尾に、同じプレゼンテーションファイル内でスライドをクローンして使用したい場合は、以下の手順に従って [AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) オブジェクトが公開する **Slides** コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/) クラスをインスタンス化します。
3. [ISlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/) オブジェクトが提供する [AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) メソッドを呼び出し、クローンするスライドをパラメータとして渡します。
4. 変更されたプレゼンテーションファイルを書き出します。

下の例では、プレゼンテーションの最初の位置（インデックス 0）にあるスライドを、プレゼンテーションの末尾にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **プレゼンテーション内の別の位置にスライドをクローンする**
同じプレゼンテーションファイル内でスライドをクローンし、別の位置で使用したい場合は、[InsertClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/insertclone/) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) オブジェクトが公開する **Slides** コレクションを参照してクラスをインスタンス化します。
3. [ISlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/) オブジェクトが提供する [InsertClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/insertclone/) メソッドを呼び出し、クローンするスライドと新しい位置のインデックスをパラメータとして渡します。
4. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

下の例では、プレゼンテーションのインデックス 0（位置 1）にあるスライドを、インデックス 1（位置 2）にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **別のプレゼンテーションの末尾にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存スライドの末尾に使用する必要がある場合は、次の手順を行います。

1. スライドのクローン元となるプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドを追加する先のプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
3. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) オブジェクトが公開する **Slides** コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/) クラスをインスタンス化します。
4. [ISlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/) オブジェクトが提供する [AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) メソッドを呼び出し、元のプレゼンテーションからのスライドをパラメータとして渡します。
5. 変更された宛先プレゼンテーションファイルを書き出します。

下の例では、ソースプレゼンテーションの最初のインデックスにあるスライドを、宛先プレゼンテーションの末尾にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **別のプレゼンテーションの別の位置にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの特定の位置に使用する必要がある場合は、次の手順を行います。

1. スライドのクローン元となるソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドを追加する先のプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
3. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/) クラスをインスタンス化します。
4. [ISlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/) オブジェクトが提供する [InsertClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/insertclone/) メソッドを呼び出し、ソースプレゼンテーションからのスライドと希望する位置をパラメータとして渡します。
5. 変更された宛先プレゼンテーションファイルを書き出します。

下の例では、ソースプレゼンテーションのインデックス 0（位置 1）にあるスライドを、宛先プレゼンテーションのインデックス 1（位置 2）にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **別のプレゼンテーションの特定の位置にスライドをクローンする**
あるプレゼンテーションからマスタースライド付きのスライドをクローンし、別のプレゼンテーションで使用する必要がある場合、まずソースプレゼンテーションから目的のマスタースライドを宛先プレゼンテーションにクローンする必要があります。その後、マスタースライドを使用してマスタースライド付きのスライドをクローンします。**AddClone(ISlide, IMasterSlide)** は、ソースプレゼンテーションではなく宛先プレゼンテーションのマスタースライドを期待します。マスタースライド付きのスライドをクローンするには、以下の手順に従ってください。

1. スライドのクローン元となるソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドをクローン先とする宛先プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
3. クローン対象のスライドとそのマスタースライドにアクセスします。
4. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) オブジェクトが公開する Masters コレクションを参照して、[IMasterSlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/) クラスをインスタンス化します。
5. [IMasterSlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslidecollection/) オブジェクトが提供する [AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) メソッドを呼び出し、ソース PPTX からクローンするマスターをパラメータとして渡します。
6. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/) クラスをインスタンス化します。
7. [ISlideCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/) オブジェクトが提供する [AddClone](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) メソッドを呼び出し、ソースプレゼンテーションからのクローン対象スライドとマスタースライドをパラメータとして渡します。
8. 変更された宛先プレゼンテーションファイルを書き出します。

下の例では、ソースプレゼンテーションのインデックス 0 にあるマスタースライド付きのスライドを、ソーススライドのマスターを使用して宛先プレゼンテーションの末尾にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **指定セクションの末尾にスライドをクローンする**
同じプレゼンテーションファイル内でスライドをクローンし、別のセクションで使用したい場合は、[**ISlideCollection**](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/) インターフェイスが提供する [**AddClone()**](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecollection/addclone/) メソッドを使用します。Aspose.Slides for C++ は、最初のセクションからスライドをクローンし、そのクローンしたスライドを同じプレゼンテーションの第2セクションに挿入することを可能にします。

次のコードスニペットは、スライドをクローンし、指定したセクションにクローンしたスライドを挿入する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **スライドサイズの一致を確保する**
スライドを別のプレゼンテーションにクローンする際は、宛先プレゼンテーションがソースと同じスライドサイズであることを確認してください。スライドサイズが異なる場合、Aspose.Slides はクローンされたシェイプのサイズを自動的に再スケーリングしません。元の座標と寸法が保持されるため、コンテンツがずれたりスライドの境界を超えて表示されたりする可能性があります。

マスターとスライドをクローンする前に、宛先プレゼンテーションのスライドサイズをソースに合わせて設定できます：

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

マスターとスライドをクローンする前にこれを行ってください。

## **FAQ**
**発表者ノートとレビュアーコメントはクローンされますか？**  
はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に [remove them](/slides/ja/cpp/presentation-notes/) してください。

**チャートとそのデータ ソースはどのように扱われますか？**  
チャートオブジェクト、書式設定、埋め込みデータはコピーされます。チャートが外部ソース（例: OLE 埋め込みワークブック）にリンクされている場合、そのリンクは [OLE object](/slides/ja/cpp/manage-ole/) として保持されます。ファイル間で移動した後は、データの利用可能性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**  
はい。特定のスライドインデックスにクローンを挿入し、選択した [section](/slides/ja/cpp/slide-section/) に配置できます。対象のセクションが存在しない場合は、まず作成し、その後スライドを移動してください。