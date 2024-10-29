---
title: スライド トランジション
type: docs
weight: 80
url: /ja/cpp/slide-transition/
keywords: "PowerPoint スライド トランジション, モーフ トランジション"
description: "PowerPoint スライド トランジション、Aspose.Slidesを使用した PowerPoint モーフ トランジション。"
---

## **スライド トランジションの追加**
理解しやすくするために、Aspose.Slides for C++を使用して、シンプルなスライドトランジションの管理方法を示します。開発者はスライドに異なるスライドトランジション効果を適用できるだけでなく、これらのトランジション効果の動作をカスタマイズすることもできます。シンプルなスライドトランジション効果を作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. Aspose.Slides for C++が提供するトランジション効果のいずれかからスライドにスライドトランジションタイプを適用します。
1. 修正されたプレゼンテーションファイルを書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **高度なスライド トランジションの追加**
上記のセクションでは、スライドにシンプルなトランジション効果を適用しました。次に、そのシンプルなトランジション効果をさらに良くし、制御できるようにするためには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. Aspose.Slides for C++が提供するトランジション効果のいずれかからスライドにスライドトランジションタイプを適用します。
1. トランジションを「クリックで進める」、「指定された時間後」、「またはその両方」に設定できます。
1. スライドトランジションが「クリックで進める」に設定されている場合、トランジションはマウスがクリックされるまで進みません。さらに、Advance After Timeプロパティが設定されている場合、指定された進行時間が経過した後にトランジションが自動的に進みます。
1. 修正されたプレゼンテーションをプレゼンテーションファイルとして書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **モーフ トランジション**
Aspose.Slides for C++は現在、モーフ トランジションをサポートしています。これは、PowerPoint 2019で導入された新しいモーフトランジションを表します。モーフトランジションを使用すると、スライドから次のスライドへの滑らかな動きをアニメーション化できます。この記事では、モーフトランジションの概念とその使用方法を説明します。モーフトランジションを効果的に使用するには、少なくとも1つの共通のオブジェクトを持つ2つのスライドが必要です。最も簡単な方法は、スライドを複製し、2番目のスライド上のオブジェクトを異なる場所に移動することです。

以下のコードスニペットは、テキストを含むスライドのクローンをプレゼンテーションに追加し、2番目のスライドにモーフタイプのトランジションを設定する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **モーフ トランジション タイプ**
新しいAspose.Slides.SlideShow.TransitionMorphType列挙型が追加されました。これは、異なるタイプのモーフスライドトランジションを表します。

TransitionMorphType列挙型には3つのメンバーがあります：

- ByObject: モーフトランジションは、形状を不可分のオブジェクトとして考慮して実行されます。
- ByWord: モーフトランジションは、可能な場合、単語ごとにテキストを移行します。
- ByChar: モーフトランジションは、可能な場合、文字ごとにテキストを移行します。

以下のコードスニペットは、スライドにモーフトランジションを設定し、モーフタイプを変更する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **トランジション効果の設定**
Aspose.Slides for C++は、ブラックから、左から、右からなどのトランジション効果の設定をサポートしています。トランジション効果を設定するには、以下の手順に従ってください：

- Presentationクラスのインスタンスを作成します。
- スライドの参照を取得します。
- トランジション効果を設定します。
- プレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、トランジション効果を設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}