---
title: プレゼンテーションのシェイプから画像を抽出する
type: docs
weight: 100
url: /ja/nodejs-java/extracting-images-from-presentation-shapes/
keywords: "画像抽出, PowerPoint, PPT, PPTX, PowerPointプレゼンテーション, Java, Aspose.Slides for Node.js via Java"
description: "JavaScriptでPowerPointプレゼンテーションから画像を抽出する"
---

{{% alert color="primary" %}} 

画像はしばしばシェイプに追加され、スライドの背景としても頻繁に使用されます。画像オブジェクトは[ImageCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection/)を通じて追加され、これは[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)オブジェクトのコレクションです。

この記事では、プレゼンテーションに追加された画像を抽出する方法を説明します。 

{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まずすべてのスライドを順に調べ、次に各シェイプを調べて画像を特定する必要があります。画像が見つかり、または識別されたら、それを抽出して新しいファイルとして保存できます。 
```javascript
function extractImages() {
    const folderPath = "./";
    const pres = new aspose.slides.Presentation(folderPath + "ExtractImages.pptx");
    let img = null;
    let backImage = null;

    let slideIndex = 0;
    let imageType = 0;
    let ifImageFound = false;

    for (let i = 0; i < pres.getSlides().size(); i++) {
        slideIndex++;
        let sl = pres.getSlides().get_Item(i);

        if (sl.getBackground().getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
            backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
            imageType = getImageTType(backImage);

            const imagePath = folderPath + "backImage_Slide_" + slideIndex + "." + imageType;
            saveImage(backImage, imagePath, imageType);
        } else if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
            backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
            imageType = getImageTType(backImage);

            const imagePath = folderPath + "backImage_LayoutSlide_" + slideIndex + "." + imageType;
            saveImage(backImage, imagePath, imageType);
        }

        for (let j = 0; j < sl.getShapes().size(); j++) {
            let sh = sl.getShapes().get_Item(j);

            if (java.instanceOf(sh, "com.aspose.slides.IAutoShape")) {
                let ashp = sh;
                if (ashp.getFillFormat().getFillType() === aspose.slides.FillType.Picture) {
                    img = ashp.getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(img);
                    ifImageFound = true;
                }
            } else if (java.instanceOf(sh, "com.aspose.slides.IPictureFrame")) {
                let pf = sh;
                img = pf.getPictureFormat().getPicture().getImage();
                imageType = getImageTType(img);
                ifImageFound = true;
            }

            if (ifImageFound) {
                const imagePath = folderPath + "backImage_Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                saveImage(img, imagePath, imageType);
            }
            ifImageFound = false;
        }
    }
}

function getImageTType(image) {
    let imageContentType = image.getContentType();
    imageContentType = imageContentType.substring(imageContentType.indexOf("/") + 1);
    imageContentType = imageContentType.substring(imageContentType.indexOf("-") + 1);
    return imageContentType;
}

function capitalize(str) {
    if (!str || str.length <= 1) return str;
    return str.charAt(0).toUpperCase() + str.slice(1);
}

function saveImage(image, path, imageType) {    
    var ImageFormatClass = java.import('com.aspose.slides.ImageFormat');
    let imageTypeValue = java.callStaticMethodSync("com.aspose.slides.ImageFormat", "getValue", ImageFormatClass.class, capitalize(imageType));
    
    image.getImage().save(path, java.newInstanceSync("java.lang.Integer", imageTypeValue.longValue));
    console.log(`Image saved to ${path}`);
}
```


## **FAQ**

**元の画像をトリミングやエフェクト、シェイプの変形なしで抽出できますか？**

はい。シェイプの画像にアクセスすると、プレゼンテーションの[image collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/)から画像オブジェクトが取得されます。つまり、トリミングやスタイリング効果のない元のピクセルです。ワークフローはプレゼンテーションの画像コレクションと[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)オブジェクトを順に処理し、生のデータを保持しています。

**多数の画像を一度に保存する際に、同一ファイルが重複して保存されるリスクはありますか？**

はい、無差別に保存すると重複する可能性があります。プレゼンテーションの[image collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/)には、異なるシェイプやスライドから参照される同一のバイナリデータが含まれることがあります。重複を防ぐには、書き込む前に抽出したデータのハッシュ、サイズ、または内容を比較してください。

**プレゼンテーションのコレクション内の特定の画像にリンクされているシェイプをどのように判別できますか？**

Aspose.Slides は[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)からシェイプへの逆リンクを保持していません。走査中に手動でマッピングを作成してください。つまり、[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)への参照を見つけたら、それを使用しているシェイプを記録します。

**添付ドキュメントなどのOLEオブジェクトに埋め込まれた画像を抽出できますか？**

直接はできません。OLE オブジェクトはコンテナであるためです。まず OLE パッケージ自体を抽出し、別のツールでその内容を解析する必要があります。プレゼンテーションの画像シェイプは[PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)を介して動作しますが、OLE は別のオブジェクトタイプです。