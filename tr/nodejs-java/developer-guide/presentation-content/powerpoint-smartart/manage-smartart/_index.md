---
title: PowerPoint Sunumlarında JavaScript Kullanarak SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt Metni
- Yerleşim Türü
- Gizli Özellik
- Organizasyon Şeması
- Resim Organizasyon Şeması
- PowerPoint
- Sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak PowerPoint SmartArt'ı oluşturmayı ve düzenlemeyi, slayt tasarımını ve otomasyonunu hızlandıran net JavaScript kod örnekleriyle öğrenin."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir yerleşimden oluşan bir PowerPoint diyagramıdır. Java aracılığıyla Node.js için Aspose.Slides ile SmartArt oluşturabilir, düğümlerindeki metni okuyabilir, yerleşimini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması yerleşimlerini yapılandırabilir ve resim organizasyon şemaları oluşturabilirsiniz.

## **Bir SmartArt Nesnesinden Metni Al**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Görünür metni okumak için [SmartArt.getAllNodes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartart/#getAllNodes--) üzerinden döngü yapın, ardından [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) tarafından döndürülen [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) öğesini okuyun.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Bir SmartArt Nesnesinin Düzen Türünü Değiştir**

SmartArt yerleşimi, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, `BasicBlockList` değerine sahip bir [SmartArtLayoutType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartartlayouttype/) kullanarak bir SmartArt nesnesi oluşturur, bunu `BasicProcess` değerine değiştirir ve sunumu kaydeder.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Et**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartartnode/ishidden/) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Seçilen yerleşim gizli düğümleri görünür diyagram öğeleri olarak göstermese bile gizli düğümler yapıda bulunabilir.

Aşağıdaki örnek, `RadialCycle` değerine sahip bir [SmartArtLayoutType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartartlayouttype/) kullanan bir SmartArt nesnesine bir düğüm ekler ve düğümün gizli durumunu kontrol eder.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Organizasyon Şeması Düzenini Al veya Ayarla**

Organizasyon şeması yerleşimi kullanan SmartArt diyagramları için [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) ve [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) alt düğümlerin bir üst düğüm altında nasıl düzenlendiğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/organizationchartlayouttype/) değerine bağlı olarak alt düğümleri soldan, sağdan veya her iki taraftan asılacak şekilde ayarlayabilirsiniz.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün yerleşimini [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` değerine ayarlar.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Resim Organizasyon Şeması Oluştur**

Resim organizasyon şeması, görüntü yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt yerleşimidir. SmartArt nesnesini bir slayta eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` değerini kullanın.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**SmartArt RTL dilleri için yansıtma veya ters çevirme destekliyor mu?**

Evet. Seçilen SmartArt yerleşimi ters çevirmeyi desteklediğinde, [SmartArt.setReversed](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartart/setreversed/) yöntemi diyagram yönünü soldan sağa’dan sağdan sola'ya değiştirir veya geri çevirir.

**SmartArt'ı aynı slayta ya da başka bir sunuma biçimlendirmeyi koruyarak nasıl kopyalarım?**

SmartArt şekli [Şekli klonlayarak](/slides/tr/nodejs-java/shape-manipulations/) [ShapeCollection.addClone](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/addclone/) ile ya da SmartArt'ı içeren tüm slaytı [klonlayarak](/slides/tr/nodejs-java/clone-slides/) kopyalayabilirsiniz. Her iki yaklaşım da boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı önizleme veya web dışa aktarımı için bir raster görüntü olarak nasıl oluştururum?**

Slaytı veya tüm sunumu PNG ya da JPEG olarak [slaytı render ederek](/slides/tr/nodejs-java/convert-powerpoint-to-png/) dışa aktarabilirsiniz. SmartArt, slaytın bir parçası olarak renderlenir.

**Bir slaytta birden fazla SmartArt nesnesi varsa belirli birini nasıl bulabilirim?**

SmartArt şekline belirgin bir [Shape.setAlternativeText](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/setalternativetext/) ya da [Shape.setName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/setname/) değeri atayın, bu değeri [BaseSlide.getShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/#getShapes) içinde arayın ve ardından eşleşen şeklin bir [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartart/) olduğundan emin olun.