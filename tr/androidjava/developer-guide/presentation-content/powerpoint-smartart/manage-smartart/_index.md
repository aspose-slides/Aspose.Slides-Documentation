---
title: Android'de PowerPoint Sunumlarında SmartArt Yönetimi
linktitle: SmartArt Yönetimi
type: docs
weight: 10
url: /tr/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt metni
- düzen türü
- gizli özelliği
- organizasyon şeması
- resim organizasyon şeması
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android için Aspose.Slides kullanarak PowerPoint SmartArt'ı oluşturmayı ve düzenlemeyi, kaydırma tasarımını ve otomasyonu hızlandıran net Java kod örnekleriyle öğrenin."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir düzenle oluşturulan bir PowerPoint diyagramıdır. Aspose.Slides for Android via Java ile SmartArt oluşturabilir, düğümlerindeki metni okuyabilir, düzenini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması düzenlerini yapılandırabilir ve resim organizasyon şemaları oluşturabilirsiniz.

## **Bir SmartArt Nesnesinden Metin Almak**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Görünür metni okumak için [ISmartArt.getAllNodes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ismartart/#getAllNodes--) üzerinden yineleme yapın, ardından [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) tarafından döndürülen [ITextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/) nesnesini okuyun.

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

## **Bir SmartArt Nesnesinin Düzen Türünü Değiştirme**

SmartArt düzeni, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, onu `BasicProcess` değerine değiştirir ve sunumu kaydeder.

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

## **Bir SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etme**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ismartartnode/#isHidden--) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Seçilen düzen, düğümleri görünür diyagram öğeleri olarak göstermese bile gizli düğümler yapıda bulunabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve düğümün gizli durumunu kontrol eder.

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

## **Organizasyon Şeması Düzenini Almak veya Ayarlamak**

Organizasyon şeması düzeni kullanan SmartArt diyagramları için [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) ve [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) alt düğümlerin bir üst düğüm altında nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OrganizationChartLayoutType) değerine bağlı olarak alt düğümleri sol, sağ veya her iki taraftan sarkıtacak şekilde ayarlayabilirsiniz.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün düzenini [OrganizationChartLayoutType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging` değerine ayarlar.

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

## **Resim Organizasyon Şeması Oluşturma**

Resim organizasyon şeması, görüntü yer tutucularını içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt düzenidir. SmartArt nesnesini bir slayta eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` değerini kullanın.

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

**SmartArt, RTL dilleri için yansıtma veya tersine çevirme destekliyor mu?**

Evet. [ISmartArt.setReversed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) yöntemi, seçilen SmartArt düzeni ters çevirmeyi destekliyorsa diyagram yönünü soldan sağa’dan sağdan sola’ya değiştirir veya tersine çevirir.

**Biçimlendirmeyi koruyarak SmartArt'ı aynı slayta veya başka bir sunuma nasıl kopyalayabilirim?**

SmartArt şekline [SmartArt şekli klonla](/slides/tr/androidjava/shape-manipulations/) ile [ShapeCollection.addClone](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) uygulayabilir veya SmartArt içeren tüm slaytı [slaytı klonla](/slides/tr/androidjava/clone-slides/) ile klonlayabilirsiniz. Her iki yöntem de boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı ön izleme veya web dışa aktarımı için raster görüntüye nasıl render edebilirim?**

Slaytı veya tüm sunumu PNG ya da JPEG olarak [render edin](/slides/tr/androidjava/convert-powerpoint-to-png/). SmartArt slaytın bir parçası olarak render edilir.

**Bir slaytta birden fazla SmartArt nesnesi varsa, belirli bir SmartArt nesnesini nasıl bulabilirim?**

SmartArt şekline ayırt edici bir [Shape.getAlternativeText](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getAlternativeText--) ya da [Shape.getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getName--) değeri atayın, bu değeri [BaseSlide.getShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/baseslide/#getShapes--) içinde arayın ve eşleşen şeklin bir [ISmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ismartart/) olduğundan emin olun.