---
title: PowerPoint Sunumlarında Java Kullanarak SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/java/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- yerleşim türü
- gizli özellik
- organizasyon şeması
- resimli organizasyon şeması
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint SmartArt'ı oluşturmayı ve düzenlemeyi, slayt tasarımını ve otomasyonu hızlandıran net kod örnekleriyle öğrenin."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir yerleşimden oluşturulan bir PowerPoint diyagramıdır. Aspose.Slides for Java ile SmartArt oluşturabilir, düğümlerinden metin okuyabilir, yerleşimini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması yerleşimlerini yapılandırabilir ve resimli organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Al**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Görünür metni okumak için [ISmartArt.getAllNodes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ismartart/#getAllNodes--) üzerinden yineleme yapın, ardından [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ismartartshape/#getTextFrame--) tarafından döndürülen [ITextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextframe/) öğesini okuyun.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt Nesnesinin Yerleşim Türünü Değiştirme**

SmartArt yerleşimi, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BasicProcess` değerine değiştirir ve sunumu kaydeder.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Et**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ismartartnode/#isHidden--) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Seçilen yerleşim, düğümü görünür diyagram öğesi olarak göstermese bile gizli düğümler yapıda bulunabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve düğümün gizli durumunu kontrol eder.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Organizasyon Şeması Yerleşimini Al veya Ayarla**

Organizasyon şeması yerleşimi kullanan SmartArt diyagramları için, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) ve [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) bir ebeveyn düğümünün altındaki alt düğümlerin nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OrganizationChartLayoutType) değerine bağlı olarak alt düğümler sola, sağa veya her iki tarafa asılacak şekilde ayarlanabilir.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün yerleşimini [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging` değerine ayarlar.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Resimli Organizasyon Şeması Oluştur**

Resimli organizasyon şeması, resim yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt yerleşimidir. Bir slayta SmartArt nesnesi eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` değerini kullanın.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**SmartArt, RTL dilleri için yansıtma veya tersleme destekliyor mu?**

Evet. [ISmartArt.setReversed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ismartart/#setReversed-boolean-) yöntemi, seçilen SmartArt yerleşimi terslemeyi desteklediğinde, diyagram yönünü soldan sağa’dan sağdan sola’ya veya tersine değiştirir.

**SmartArt'ı aynı slayta ya da başka bir sunuma formatı koruyarak nasıl kopyalayabilirim?**

SmartArt şekli [SmartArt şekli klonla](/slides/tr/java/shape-manipulations/) ile [ShapeCollection.addClone](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) kullanarak veya SmartArt'ı içeren slaytı [tüm slaytı klonla](/slides/tr/java/clone-slides/) ile kopyalayabilirsiniz. Her iki yaklaşım da boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı önizleme veya web dışa aktarımı için bir raster görüntüye nasıl dönüştürürüm?**

[Slaytı render et](/slides/tr/java/convert-powerpoint-to-png/) veya tüm sunumu PNG veya JPEG'ye dönüştürün. SmartArt, slaytın bir parçası olarak render edilir.

**Bir slaytta birkaç SmartArt nesnesi varsa belirli bir SmartArt nesnesini nasıl bulabilirim?**

SmartArt şekli üzerinde ayırt edici bir [Shape.getAlternativeText](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getAlternativeText--) veya [Shape.getName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getName--) değeri ayarlayın, bu değeri [BaseSlide.getShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/baseslide/#getShapes--) içinde arayın ve eşleşen şeklin bir [ISmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ismartart/) olduğundan emin olun.