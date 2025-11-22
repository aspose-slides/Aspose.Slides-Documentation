---
title: プレゼンテーション内のスライドへのアクセス
type: docs
weight: 20
url: /ja/nodejs-java/access-slide-in-presentation/
keywords: "PowerPoint プレゼンテーションにアクセス, スライドにアクセス, スライドのプロパティを編集, スライドの位置を変更, スライド番号を設定, インデックス, ID, 位置 Java, Aspose.Slides"
description: "インデックス、ID、または位置で PowerPoint スライドに JavaScript でアクセスします。スライドのプロパティを編集"
---

Aspose.Slides は、スライドにインデックスと ID の 2 つの方法でアクセスできます。

## **Access Slide by Index**
プレゼンテーション内のすべてのスライドは、スライドの位置に基づき 0 から始まる数値で配置されています。最初のスライドはインデックス 0、2 番目のスライドはインデックス 1…というようにアクセスできます。

プレゼンテーション ファイルを表す Presentation クラスは、すべてのスライドを [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/)（[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) オブジェクトのコレクション）として公開します。この JavaScript コードは、インデックスを使用してスライドにアクセスする方法を示しています:
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // スライドインデックスを使用してスライドにアクセス
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **Access Slide by ID**
プレゼンテーション内の各スライドには一意の ID が付与されています。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスが提供する [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-) メソッドを使用してその ID を指定できます。この JavaScript コードは、有効なスライド ID を指定し、[getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-) メソッドでスライドにアクセスする方法を示しています:
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // スライド ID を取得します
    var id = pres.getSlides().get_Item(0).getSlideId();
    // ID を使用してスライドにアクセスします
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **Change Slide Position**
Aspose.Slides ではスライドの位置を変更できます。たとえば、最初のスライドを 2 番目にすることができます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. インデックスで位置を変更したいスライドの参照を取得します。  
1. [setSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#setSlideNumber-int-) プロパティでスライドの新しい位置を設定します。  
1. 変更後のプレゼンテーションを保存します。

この JavaScript コードは、位置 1 のスライドを位置 2 に移動する操作を示しています:
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 位置が変更されるスライドを取得します
    var sld = pres.getSlides().get_Item(0);
    // スライドの新しい位置を設定します
    sld.setSlideNumber(2);
    // 変更されたプレゼンテーションを保存します
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


最初のスライドが 2 番目になり、2 番目のスライドが 1 番目になります。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **Set Slide Number**
[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスが提供する [setFirstSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) プロパティを使用すると、プレゼンテーションの最初のスライドに新しい番号を設定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. スライド番号を取得します。  
1. スライド番号を設定します。  
1. 変更後のプレゼンテーションを保存します。

この JavaScript コードは、最初のスライド番号を 10 に設定する操作を示しています:
```javascript
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // スライド番号を取得します
    var firstSlideNumber = pres.getFirstSlideNumber();
    // スライド番号を設定します
    pres.setFirstSlideNumber(10);
    // 変更されたプレゼンテーションを保存します
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


最初のスライドをスキップしたい場合は、2 番目のスライドから番号付けを開始し（最初のスライドの番号付けは非表示に）次のようにします:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // プレゼンテーションの最初のスライドの番号を設定します
    // すべてのスライドのスライド番号を表示します
    // 最初のスライドのスライド番号を非表示にします
    // 変更されたプレゼンテーションを保存します
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**スライド番号は、コレクションのゼロベースのインデックスと一致しますか？**  
スライドに表示される番号は任意の値（例: 10）から開始でき、インデックスと一致する必要はありません。この関係はプレゼンテーションの [first slide number](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) 設定で制御されます。

**非表示スライドはインデックスに影響しますか？**  
はい。非表示スライドはコレクション内に残り、インデックスの計算に含まれます。「非表示」は表示状態を指すだけで、コレクション内の位置には影響しません。

**他のスライドが追加または削除されたときにインデックスは変わりますか？**  
はい。インデックスは常にスライドの現在の順序を反映し、挿入、削除、移動操作が行われるたびに再計算されます。