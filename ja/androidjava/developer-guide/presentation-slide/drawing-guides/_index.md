---
title: Android でのプレゼンテーションにおける描画ガイドの管理
linktitle: 描画ガイド
type: docs
weight: 85
url: /ja/androidjava/drawing-guides/
keywords:
- 描画ガイド
- 水平ガイド
- 垂直ガイド
- 整列ガイド
- スライドビュー
- マスタースライド
- レイアウトスライド
- ノートマスター
- 配布資料マスター
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint プレゼンテーションに水平および垂直の描画ガイドを追加、アクセス、クリアする。"
---
## **概要**

描画ガイドは、調整可能な水平および垂直の線で、PowerPointでプレゼンテーションを編集する際にユーザーが図形を一貫して配置できるよう支援します。特に、アプリケーションがプレゼンテーションを生成し、後で手動で調整する場合に有用です。アプリケーションは、コンテンツの追加や移動時に作者が従うべき同じ配置支援を保存できます。

描画ガイドは編集支援であり、スライドのコンテンツではありません。スライドショーやレンダリングされた出力には表示されません。Aspose.Slides for Android via Java は、[IDrawingGuidesCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idrawingguidescollection/) インターフェイスを通じてそれらを公開します。ガイドは[IDrawingGuide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idrawingguide/)で表され、方向、位置、色を持ちます。

位置は、対象のスライドまたはマスターの左上隅からのポイントで測定されます。垂直ガイドは水平座標を使用し、通常は 0 からスライド幅までの範囲です。水平ガイドは垂直座標を使用し、通常は 0 からスライド高さまでの範囲です。

## **スライドビューへのガイドの追加**

通常のスライドを編集している間に表示されるガイドを管理するには、[ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) を使用します。ポイント単位の位置と[Orientation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/orientation/) の値を指定して、[IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) を呼び出します。

次の例は、スライドの中心の右側に垂直ガイドを 1 本、下側に水平ガイドを 1 本追加します。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **描画ガイドへのアクセス**

既存のガイドへアクセスするには、[IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) および [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) メソッドを使用します。 [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idrawingguide/#getOrientation--)、[IDrawingGuide.getPosition](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idrawingguide/#getPosition--)、および [IDrawingGuide.getColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idrawingguide/#getColor--) メソッドは、対応する setter メソッドで変更可能な値を返します。

次の例は、上記で作成したプレゼンテーションからスライドビューのガイドを読み取ります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **マスタースライドとレイアウトスライドへのガイドの追加**

スライドマスターとその各レイアウトスライドは、それぞれ独自の描画ガイドコレクションを持つことができます。マスタースライドには[IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) を、レイアウトスライドには[ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) を使用します。

次の例は、最初のマスタースライドに垂直ガイドを、最初のレイアウトスライドに水平ガイドを追加します。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ノートマスターと配布資料マスターへのガイドの追加**

ノートマスターと配布資料マスターも描画ガイドをサポートしています。それらのコレクションにアクセスするには、[IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) と [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) を使用します。プレゼンテーションにこれらのマスターが存在しない場合、[IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) または [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) がデフォルトのマスターを作成し、返します。

次の例は、ノートマスターに水平ガイドを、配布資料マスターに垂直ガイドを追加します。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **描画ガイドのクリア**

特定のコレクションからすべてのガイドを削除するには、[IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) を呼び出します。一つのコレクションをクリアしても、別のスコープに保存されているガイドには影響しません。

次の例は、スライドビューのガイドおよびスライドマスター、レイアウトスライド、ノートマスター、配布資料マスター上のすべてのガイドを、欠落したマスターを作成せずにクリアします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**描画ガイドはスライドショーやエクスポートされた画像に表示されますか？**

いいえ。描画ガイドは編集用の配置支援であり、プレゼンテーションのコンテンツとしてレンダリングされません。

**個々の通常スライドに直接描画ガイドを追加できますか？**

通常スライドの編集ガイドはプレゼンテーションのスライドビュー プロパティに保存されます。スライドマスター、レイアウトスライド、ノートマスター、配布資料マスター用の別個のガイドコレクションも用意されています。

**ガイドの位置にはどの単位が使用されますか？**

位置はポイントで指定され、1 インチは 72 ポイントです。垂直位置は左端から、水平位置は上端から測定されます。

**描画ガイドをクリアすると、図形が削除されたりスライドのコンテンツが変更されたりしますか？**

いいえ。[IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) メソッドは、選択されたコレクション内のガイドのみを削除します。図形やその他のスライドコンテンツは変更されません。