---
title: Java でのプレゼンテーションにおける描画ガイドの管理
linktitle: 描画ガイド
type: docs
weight: 85
url: /ja/java/drawing-guides/
keywords:
- 描画ガイド
- 水平ガイド
- 垂直ガイド
- 配置ガイド
- スライドビュー
- マスタースライド
- レイアウトスライド
- ノートマスター
- ハンドアウトマスター
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションに水平および垂直の描画ガイドを追加、アクセス、クリアします。"
---
## **概要**

描画ガイドは、調整可能な水平および垂直の線で、PowerPoint でプレゼンテーションを編集する際にユーザーが図形を一貫して配置できるよう支援します。アプリケーションがプレゼンテーションを生成し、後で手動で調整する場合に特に有用です。アプリケーションは、コンテンツを追加または移動する際に作者が従うべき同じ配置補助を保存できます。

描画ガイドは編集用の補助であり、スライド コンテンツではありません。スライドショーやレンダリングされた出力には表示されません。Aspose.Slides for Java はこれらを[IDrawingGuidesCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idrawingguidescollection/)インターフェイスで公開します。ガイドは[IDrawingGuide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idrawingguide/)で表され、向き、位置、色を持ちます。

位置は対象のスライドまたはマスターの左上隅からポイントで測定されます。垂直ガイドは水平座標を使用し、通常はスライド幅の 0 から最大幅までです。水平ガイドは垂直座標を使用し、通常はスライド高さの 0 から最大高さまでです。

## **スライドビューへのガイドの追加**

[ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) を使用して、通常スライドの編集時に表示されるガイドを管理します。[IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) を呼び出し、[Orientation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/orientation/) 値とポイント単位の位置を指定します。

次の例は、スライドの中心の右側に垂直ガイドを 1 本、下側に水平ガイドを 1 本追加します。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **描画ガイドへのアクセス**

[IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idrawingguidescollection/#getCount--) と[IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) メソッドで既存のガイドにアクセスできます。[IDrawingGuide.getOrientation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idrawingguide/#getOrientation--)、[IDrawingGuide.getPosition](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idrawingguide/#getPosition--)、および[IDrawingGuide.getColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idrawingguide/#getColor--) メソッドは値を返し、対応するセッターで変更できます。

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

スライドマスターおよび各レイアウトスライドは独自の描画ガイド コレクションを持つことができます。マスタースライドには[IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/#getDrawingGuides--) を、レイアウトスライドには[ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) を使用します。

次の例は、最初のマスタースライドに垂直ガイドを、最初のレイアウトスライドに水平ガイドを追加します。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ノートマスターとハンドアウトマスターへのガイドの追加**

ノートマスターおよびハンドアウトマスターも描画ガイドをサポートします。[IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) と[IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) を使用してそれらのコレクションにアクセスします。プレゼンテーションにこれらのマスターが存在しない場合、[IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) または[IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) がデフォルトマスターを作成して返します。

次の例は、ノートマスターに水平ガイドを、ハンドアウトマスターに垂直ガイドを追加します。

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **描画ガイドのクリア**

[IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idrawingguidescollection/#clear--) を呼び出すことで、特定のコレクションからすべてのガイドを削除できます。1 つのコレクションをクリアしても、別のスコープに保存されたガイドには影響しません。

次の例は、スライドビューのガイドとスライドマスター、レイアウトスライド、ノートマスター、ハンドアウトマスター上のすべてのガイドを、マスターが欠落していても作成せずにクリアします。

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

いいえ。描画ガイドは編集用の配置補助であり、プレゼンテーションのコンテンツとして描画されません。

**個々の通常スライドに直接描画ガイドを追加できますか？**

通常スライドの編集ガイドはプレゼンテーションのスライドビュー プロパティに保存されます。スライドマスター、レイアウトスライド、ノートマスター、ハンドアウトマスター用の別個のガイドコレクションが用意されています。

**ガイド位置にはどの単位が使用されますか？**

位置はポイントで指定され、72 ポイントが 1 インチに相当します。垂直位置は左端から、水平位置は上端から測定されます。

**描画ガイドをクリアしてもシェイプが削除されたりスライドコンテンツが変更されたりしますか？**

いいえ。[IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/idrawingguidescollection/#clear--) メソッドは選択されたコレクション内のガイドのみを削除します。シェイプやその他のスライド コンテンツは変更されません。