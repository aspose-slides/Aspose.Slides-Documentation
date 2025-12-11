---
title: C++ を使用したプレゼンテーションのスライド遷移の管理
linktitle: スライド遷移
type: docs
weight: 80
url: /ja/cpp/slide-transition/
keywords:
- スライド遷移
- スライド遷移の追加
- スライド遷移の適用
- 高度なスライド遷移
- モーフ遷移
- 遷移タイプ
- 遷移効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でスライド遷移をカスタマイズする方法を、PowerPoint と OpenDocument のプレゼンテーション向けにステップバイステップで解説します。"
---

## **スライドトランジションの追加**
理解しやすくするために、Aspose.Slides for C++ を使用してシンプルなスライド遷移を管理する方法を示しました。開発者はスライドにさまざまな遷移効果を適用できるだけでなく、これらの遷移効果の動作をカスタマイズすることもできます。シンプルなスライド遷移効果を作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. Aspose.Slides for C++ が提供する TransitionType 列挙体を使用して、スライドにスライド遷移タイプを適用します。
1. 変更したプレゼンテーションファイルを書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **高度なスライド遷移の追加**
前のセクションでは、スライドにシンプルな遷移効果を適用しました。今度は、そのシンプルな遷移効果をさらに高度かつ制御可能にするため、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. Aspose.Slides for C++ が提供する遷移効果のいずれかを使用して、スライドにスライド遷移タイプを適用します。
1. 遷移をクリックで進む (Advance On Click)、特定の時間後に進む、またはその両方に設定することもできます。
1. スライド遷移がクリックで進むように設定されている場合、マウスクリック時にのみ遷移が進みます。さらに、Advance After Time プロパティが設定されている場合、指定された時間が経過すると自動的に遷移が進みます。
1. 変更したプレゼンテーションをプレゼンテーションファイルとして書き込みます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **モーフ遷移**
Aspose.Slides for C++ は現在、モーフ遷移をサポートしています。これは PowerPoint 2019 で導入された新しいモーフ遷移を指します。モーフ遷移を使用すると、あるスライドから次のスライドへの滑らかな動きをアニメーション化できます。本稿ではモーフ遷移の概念と使用方法について説明します。モーフ遷移を効果的に使用するには、少なくとも1つの共通オブジェクトを持つ2枚のスライドが必要です。最も簡単な方法はスライドを複製し、2枚目のスライドでオブジェクトを別の位置に移動させることです。

以下のコードスニペットは、テキストを含むスライドのクローンをプレゼンテーションに追加し、2枚目のスライドにモーフタイプの遷移を設定する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **モーフ遷移の種類**
新しい Aspose.Slides.SlideShow.TransitionMorphType 列挙体が追加されました。これはモーフスライド遷移のさまざまなタイプを表します。

TransitionMorphType 列挙体には3つのメンバーがあります。

- ByObject: シェイプを分割できないオブジェクトとして扱い、モーフ遷移を実行します。
- ByWord: 可能な場合、テキストを単語単位で転送してモーフ遷移を実行します。
- ByChar: 可能な場合、テキストを文字単位で転送してモーフ遷移を実行します。

以下のコードスニペットは、スライドにモーフ遷移を設定し、モーフタイプを変更する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **遷移効果の設定**
Aspose.Slides for C++ は、黒から、左から、右からなどの遷移効果の設定をサポートしています。遷移効果を設定するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。
- スライドの参照を取得します。
- 遷移効果を設定します。
- プレゼンテーションを PPTX ファイルとして書き込みます。

以下の例では、遷移効果を設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**スライド遷移の再生速度を制御できますか？**

はい。遷移の [speed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) を [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) 設定で設定します（例: slow/medium/fast）。

**遷移に音声を添付してループさせることはできますか？**

はい。遷移にサウンドを埋め込むことができ、サウンドモードやループなどの設定で動作を制御できます（例: [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), 加えてメタデータとして [set_SoundIsBuiltIn](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) と [set_SoundName](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)）。

**すべてのスライドに同じ遷移を適用する最速の方法は何ですか？**

各スライドの遷移設定で目的の遷移タイプを設定します。遷移はスライド単位で保存されるため、すべてのスライドに同じタイプを適用すれば一貫した結果が得られます。

**スライドに現在設定されている遷移を確認するにはどうすればよいですか？**

スライドの [transition settings](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_slideshowtransition/) を確認し、その [transition type](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/get_type/) を取得します。その値が適用されている効果を正確に示します。