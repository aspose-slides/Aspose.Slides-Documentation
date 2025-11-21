---
title: SmartArt シェイプの管理
type: docs
weight: 20
url: /ja/nodejs-java/manage-smartart-shape/
---

## **SmartArt シェイプの作成**
Aspose.Slides for Node.js via Java は SmartArt シェイプを作成する API を提供しています。スライドに SmartArt シェイプを作成するには、以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. LayoutType を設定して [Add a SmartArt shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) を使用します。[LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。
```javascript
// Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation();
try {
    // 最初のスライドを取得
    var slide = pres.getSlides().get_Item(0);
    // Smart Art シェイプを追加
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // プレゼンテーションを保存
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**図: スライドに追加された SmartArt シェイプ**|

## **スライド内の SmartArt シェイプへのアクセス**
以下のコードは、プレゼンテーション スライドに追加された SmartArt シェイプにアクセスするために使用します。サンプルコードでは、スライド内のすべてのシェイプを走査し、それが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) シェイプかどうかを確認します。シェイプが SmartArt タイプである場合、[**SmartArt**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) インスタンスに型キャストします。
```javascript
// 要求されたプレゼンテーションをロード
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // シェイプが SmartArt タイプか確認
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // シェイプを SmartArtEx に型キャスト
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **特定のレイアウトタイプを持つ SmartArt シェイプへのアクセス**
以下のサンプルコードは、特定の LayoutType を持つ [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) シェイプにアクセスするのに役立ちます。SmartArt の LayoutType は読み取り専用であり、[SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) シェイプが追加される際にのみ設定されるため、変更できないことに注意してください。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型キャストします。
1. 特定の LayoutType を持つ SmartArt シェイプを確認し、その後に必要な処理を実行します。
```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // シェイプが SmartArt タイプか確認
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // シェイプを SmartArtEx に型キャスト
            var smart = shape;
            // SmartArt のレイアウトをチェック
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt シェイプのスタイル変更**
この例では、任意の SmartArt シェイプのクイックスタイルを変更する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型キャストします。
1. 特定の Style を持つ SmartArt シェイプを検索します。
1. SmartArt シェイプに新しい Style を設定します。
1. プレゼンテーションを保存します。
```javascript
// Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライドを取得
    var slide = pres.getSlides().get_Item(0);
    // 最初のスライド内のすべてのシェイプを走査
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // シェイプが SmartArt タイプか確認
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // シェイプを SmartArtEx に型キャスト
            var smart = shape;
            // SmartArt のスタイルをチェック
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // SmartArt のスタイルを変更
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // プレゼンテーションを保存
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**図: スタイルが変更された SmartArt シェイプ**|

## **SmartArt シェイプのカラー スタイル変更**
この例では、任意の SmartArt シェイプのカラースタイルを変更する方法を学びます。以下のサンプルコードでは、特定のカラースタイルを持つ SmartArt シェイプにアクセスし、そのスタイルを変更します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型キャストします。
1. 特定の Color Style を持つ SmartArt シェイプを検索します。
1. SmartArt シェイプに新しい Color Style を設定します。
1. プレゼンテーションを保存します。
```javascript
// Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライドを取得
    var slide = pres.getSlides().get_Item(0);
    // 最初のスライド内のすべてのシェイプを走査
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // シェイプが SmartArt タイプか確認
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // シェイプを SmartArtEx に型キャスト
            var smart = shape;
            // SmartArt のカラースタイルをチェック
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // SmartArt のカラースタイルを変更
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // プレゼンテーションを保存
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**図: カラースタイルが変更された SmartArt シェイプ**|

## **FAQ**

**SmartArt を単一オブジェクトとしてアニメーションできますか？**

はい。SmartArt はシェイプなので、他のシェイプと同様にアニメーション API を使用して [standard animations](/slides/ja/nodejs-java/powerpoint-animation/)（出入り、強調、モーションパスなど）を適用できます。

**スライド上で内部 ID が分からない場合、特定の SmartArt をどうやって見つけますか？**

代替テキスト (AltText) を設定して使用し、その値でシェイプを検索します。これは対象シェイプを特定する推奨方法です。

**SmartArt を他のシェイプとグループ化できますか？**

はい。SmartArt を他のシェイプ（画像、テーブルなど）とグループ化でき、その後 [manipulate the group](/slides/ja/nodejs-java/group/) を使用して操作できます。

**特定の SmartArt の画像（プレビューやレポート用など）を取得するにはどうすればよいですか？**

シェイプのサムネイル／画像をエクスポートします。ライブラリはシェイプを個別に [render individual shapes](/slides/ja/nodejs-java/create-shape-thumbnails/) してラスターファイル（PNG/JPG/TIFF）に出力できます。

**プレゼンテーション全体を PDF に変換した際、SmartArt の外観は維持されますか？**

はい。レンダリングエンジンは [PDF export](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) において高忠実度を目指しており、さまざまな品質や互換性オプションが用意されています。