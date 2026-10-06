---
title: JavaScript Kullanarak PowerPoint Sunumlarında SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- yerleşim türü
- gizli özelliği
- organizasyon şeması
- resimli organizasyon şeması
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak açık JavaScript kod örnekleriyle PowerPoint SmartArt'i oluşturmayı ve düzenlemeyi öğrenin; bu örnekler slayt tasarımı ve otomasyonunu hızlandırır."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir yerleşimden oluşturulan bir PowerPoint diyagramıdır. Aspose.Slides for Node.js via Java ile SmartArt oluşturabilir, düğümlerindeki metni okuyabilir, yerleşimini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması yerleşimlerini yapılandırabilir ve resimli organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Al**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Düğüm şekillerinden metni okumak için [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/) üzerinden yineleyin, ardından [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/) tarafından döndürülen [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) okuyun.

Örnek, en az bir slaytı ve o slaytta ilk şekil olarak bir SmartArt nesnesi içeren bir sunum gerektirir. Her mevcut metin çerçevesini konsola yazdırır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```
## **SmartArt Nesnesinin Yerleşim Türünü Değiştir**

SmartArt yerleşimi, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BasicProcess` değerine değiştirir ve sunumu kaydeder. [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/)’a geçirilen konum ve boyut noktalar cinsindendir. Yerleşimi değiştirmek için [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) kullanın.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Et**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Seçilen yerleşim, düğümü görünür diyagram öğesi olarak göstermese bile, gizli düğümler yapıda bulunabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve eklenen düğümün gizli durumunu kontrol eder. Düğüm gizli ise bir mesaj yazdırır ve diyagramı kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Organizasyon Şeması Yerleşimini Al veya Ayarla**

Organizasyon şeması yerleşimi kullanan SmartArt diyagramları için, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) ve [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) alt düğümlerin bir üst düğüm altında nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) değerine bağlı olarak alt düğümleri soldan, sağdan veya her iki taraftan sarkan şekilde ayarlayabilirsiniz.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün yerleşimini [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` değerine ayarlar. Sıfır tabanlı `0` indeksi ilk üst düzey düğümü seçer; alt düğümleri seçilen düzeni kullanır. Değiştirilmiş sunum daha sonra kaydedilir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Resimli Organizasyon Şeması Oluştur**

Resimli organizasyon şeması, görüntü yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt yerleşimidir. Bir slayta SmartArt nesnesi eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` değerini kullanın. Bu örnek, görüntü yer tutucuları içeren bir diyagramı kaydeder; yer tutuculara görüntü eklemez.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Eski Diyagramları Şekil Gruplarına Dönüştür**

Mevcut bir sunumu modernleştirirken, PowerPoint 97–2003’te oluşturulmuş bir organizasyon şemasını güncellemeniz gerekebilir. Aspose.Slides bu eski diyagramları [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) nesneleri olarak temsil eder. Bir diyagramı, bireysel görsel öğeleri düzenleyebilmek için şekil grubu haline dönüştürmek üzere [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) kullanın. Ayrıntılar için [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) adresine bakın.

Dönüştürme, orijinal diyagramı kaldırmadan şekil koleksiyonuna yeni bir grup ekler. Dönüşüm başarılı olduktan sonra, kopya içeriği önlemek için orijinali [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) ile kaldırın. Şekil ekleme ve kaldırma işlemleri yinelemeyi bozmasın diye, dönüştürmeden önce eski diyagramları bir listeye toplayın.

Aşağıdaki örnek bir sunumu açar, her slaytı arar, diyagramları şekil gruplarına dönüştürür ve güncellenmiş sunumu PPTX olarak kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaydedilen sunum, dönüştürülmüş eski diyagramların yerine düzenlenebilir şekil grupları içerir; yanlarında orijinal diyagram kalmaz. PPTX'i PowerPoint'te açarak her grup içindeki metin, doldurma veya konum gibi bireysel öğeleri düzenleyebilirsiniz.

## **FAQ**

**SmartArt, RTL dilleri için yansıtma veya ters çevirme destekliyor mu?**

Evet. Seçili SmartArt yerleşimi ters çevirme destekliyorsa, [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) yöntemi diyagram yönünü soldan sağa’dan sağdan sola’ya veya geri çevirir.

**SmartArt'ı aynı slayta ya da başka bir sunuma biçimlendirmeyi koruyarak nasıl kopyalarım?**

SmartArt şekli, [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) ile [clone the SmartArt shape](/slides/tr/nodejs-java/shape-manipulations/) veya SmartArt içeren tüm slaytı [clone the whole slide](/slides/tr/nodejs-java/clone-slides/) ile kopyalayabilirsiniz. Her iki yaklaşım da boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı önizleme veya web dışa aktarımı için bir raster görüntüye nasıl render ederim?**

[Slaytı Render Et](/slides/tr/nodejs-java/convert-powerpoint-to-png/) veya tüm sunumu PNG veya JPEG'e dönüştürün. SmartArt, slaytın bir parçası olarak render edilir.

**Bir slaytta birden fazla SmartArt nesnesi varsa belirli bir SmartArt nesnesini nasıl bulabilirim?**

SmartArt şekline ayırt edici bir alternatif metin veya ad atamak için [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) veya [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) kullanın, bu değeri [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) içinde arayın ve eşleşen şeklin bir [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/) olduğundan emin olun.