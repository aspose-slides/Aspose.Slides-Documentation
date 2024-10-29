---
title: スライドのクローン
type: docs
weight: 40
url: /ja/cpp/clone-slides/
---

## **プレゼンテーション内のスライドをクローン**
クローンとは、何かの正確なコピーまたは複製を作成するプロセスです。Aspose.Slides for C++を使用すると、任意のスライドのコピーまたはクローンを作成し、そのクローンスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することができます。スライドのクローンを作成するプロセスでは、元のスライドを変更することなく、開発者が修正できる新しいスライドが作成されます。スライドをクローンする方法はいくつかあります：

- プレゼンテーション内の最後にクローン。
- プレゼンテーション内の別の位置にクローン。
- 別のプレゼンテーションの最後にクローン。
- 別のプレゼンテーションの別の位置にクローン。
- 別のプレゼンテーションの特定の位置にクローン。

Aspose.Slides for C++では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトによって公開された（[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)オブジェクトのコレクション）は、上記の種類のスライドクローンを実行するための[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index)および[InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index)メソッドを提供します。

## **プレゼンテーション内の最後にクローン**
スライドをクローンし、その既存のスライドの最後に同じプレゼンテーションファイル内で使用したい場合は、以下の手順に従って[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index)メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトによって公開されたスライドコレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)クラスをインスタンス化します。
3. [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)オブジェクトによって公開された[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index)メソッドを呼び出し、クローン対象のスライドを[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index)メソッドのパラメータとして渡します。
4. 修正されたプレゼンテーションファイルを保存します。

以下の例では、プレゼンテーションの最初の位置（ゼロインデックス）にあるスライドをプレゼンテーションの最後にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **プレゼンテーション内の別の位置にクローン**
スライドをクローンし、同じプレゼンテーションファイル内で異なる位置に使用したい場合は、[InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index)メソッドを使用します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトによって公開された**Slides**コレクションを参照して、クラスをインスタンス化します。
3. [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)オブジェクトによって公開された[InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index)メソッドを呼び出し、新しい位置のインデックスとともにクローン対象のスライドを[InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index)メソッドのパラメータとして渡します。
4. 修正されたプレゼンテーションをPPTXファイルとして保存します。

以下の例では、プレゼンテーションのゼロインデックス（位置1）にあるスライドをインデックス1（位置2）にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **別のプレゼンテーションの最後にスライドをクローン**
1つのプレゼンテーションからスライドをクローンし、他のプレゼンテーションファイルで使用したい場合、すなわち既存のスライドの後に：

1. スライドをクローンするプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドを追加する目的のプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
3. 目的のプレゼンテーションの[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトによって公開された**Slides**コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)クラスをインスタンス化します。
4. [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)オブジェクトによって公開された[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index)メソッドを呼び出し、ソースプレゼンテーションからのスライドを[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index)メソッドのパラメータとして渡します。
5. 修正された目的のプレゼンテーションファイルを保存します。

以下の例では、ソースプレゼンテーションの最初のインデックスからスライドを目的のプレゼンテーションの最後にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **別のプレゼンテーションの別の位置にスライドをクローン**
1つのプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルで特定の位置に使用したい場合：

1. スライドをクローンするソースプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドを追加するプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
3. 目的のプレゼンテーションの[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトによって公開されたスライドコレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)クラスをインスタンス化します。
4. [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)オブジェクトによって公開された[InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index)メソッドを呼び出し、ソースプレゼンテーションのスライドとともに希望の位置を[InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index)メソッドのパラメータとして渡します。
5. 修正された目的のプレゼンテーションファイルを保存します。

以下の例では、ソースプレゼンテーションのゼロインデックスからスライドを目的のプレゼンテーションのインデックス1（位置2）にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **別のプレゼンテーションの特定の位置にスライドをクローン**
マスタースライドを持つスライドを1つのプレゼンテーションからクローンし、他のプレゼンテーションで使用する必要がある場合、最初にソースプレゼンテーションから目的のマスタースライドを目的のプレゼンテーションにクローンする必要があります。その後、マスタースライドとともにスライドをクローンするためにそのマスタースライドを使用する必要があります。[AddClone(ISlide, IMasterSlide)](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index)は、ソースプレゼンテーションではなく目的のプレゼンテーションからマスタースライドを期待します。マスタースライドを持つスライドをクローンするには、以下の手順に従ってください。

1. スライドをクローンするソースプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドをクローンする目的のプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
3. クローン対象のスライドとマスタースライドにアクセスします。
4. 目的のプレゼンテーションの[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトによって公開されたマスターコレクションを参照して、[IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection)クラスをインスタンス化します。
5. [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection)オブジェクトによって公開された[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index)メソッドを呼び出し、ソースPPTXからクローンするマスターを[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index)メソッドのパラメータとして渡します。
6. 目的のプレゼンテーションの[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトによって公開されたスライドコレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)クラスをインスタンス化します。
7. [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)オブジェクトによって公開された[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index)メソッドを呼び出し、クローン対象のソースプレゼンテーションのスライドとマスタースライドを[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index)メソッドのパラメータとして渡します。
8. 修正された目的のプレゼンテーションファイルを保存します。

以下の例では、ソースプレゼンテーションのゼロインデックスにあるマスタースライドを持つスライドを、ソーススライドのマスタースライドを使用して目的のプレゼンテーションの最後にクローンしています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **指定されたセクションにスライドをクローン**
スライドをクローンし、その後同じプレゼンテーションファイル内の異なるセクションで使用したい場合は、[**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a46981dac8b18355531a04a70c70c444b)メソッドを、[**ISlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)インターフェースによって公開されたものを使用します。Aspose.Slides for C++を使用すると、最初のセクションからスライドをクローンし、その後そのクローンされたスライドを同じプレゼンテーションの第二のセクションに挿入することが可能です。

以下のコードスニペットでは、スライドをクローンし、クローンされたスライドを指定されたセクションに挿入する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}