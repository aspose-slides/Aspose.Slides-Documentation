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
- resimli organizasyon şeması
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint SmartArt'ı oluşturmayı ve düzenlemeyi, slayt tasarımı ve otomasyonu hızlandıran net Java kod örnekleri kullanarak öğrenin."
---
## **Genel Bakış**

SmartArt, düğümler, düğüm şekilleri ve bir düzen kullanılarak oluşturulan bir PowerPoint diyagramıdır. Aspose.Slides for Android via Java ile SmartArt oluşturabilir, düğümlerinden metin okuyabilir, düzenini değiştirebilir, gizli düğümleri inceleyebilir, organizasyon şeması düzenlerini yapılandırabilir ve resimli organizasyon şemaları oluşturabilirsiniz.

## **SmartArt Nesnesinden Metin Almak**

Bir SmartArt düğümü bir veya daha fazla şekil içerebilir. Düğüm şekillerinden metin okumak için [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--) üzerinden yineleme yapın, ardından [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) tarafından döndürülen [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) öğesini okuyun.

Örnek, en az bir slaytı ve o slaytta ilk şekil olarak bir SmartArt nesnesi içeren bir sunum gerektirir. Kullanılabilir her metin çerçevesini konsola yazdırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt Nesnesinin Düzen Türünü Değiştirmek**

SmartArt düzeni, düğümlerin nasıl düzenlendiğini ve bağlandığını kontrol eder. Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList` değerine sahip bir SmartArt nesnesi oluşturur, bunu `BasicProcess` değerine değiştirir ve sunumu kaydeder. [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) yöntemine geçirilen konum ve boyut noktalar (points) cinsinden ölçülür. Düzeni değiştirmek için [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SmartArt Düğümünün Gizli Olup Olmadığını Kontrol Etmek**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) düğümün SmartArt veri modelinde gizli olup olmadığını gösterir. Gizli düğümler, seçilen düzen onları görünür diyagram öğeleri olarak göstermese bile yapıda bulunabilir.

Aşağıdaki örnek, [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle` değerini kullanan bir SmartArt nesnesine bir düğüm ekler ve eklenen düğümün gizli durumunu kontrol eder. Düğüm gizli ise bir mesaj yazdırır ve diyagramı kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Organizasyon Şeması Düzenini Almak veya Ayarlamak**

Organizasyon şeması düzeni kullanan SmartArt diyagramları için, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) ve [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) çocuk düğümlerin bir üst düğüm altında nasıl düzenleneceğini tanımlar. Örneğin, seçilen [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) değerine bağlı olarak çocuk düğümleri soldan, sağdan ya da her iki taraftan sarkıtacak şekilde ayarlayabilirsiniz.

Aşağıdaki örnek bir organizasyon şeması oluşturur ve ilk düğümün düzenini [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging` değerine ayarlar. Sıfırdan başlayan `0` indeksi, ilk üst düzey düğümü seçer; onun çocuk düğümleri seçilen düzeni kullanır. Değiştirilmiş sunum daha sonra kaydedilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Resimli Organizasyon Şeması Oluşturma**

Resimli organizasyon şeması, görüntü yer tutucuları içeren hiyerarşi diyagramları için tasarlanmış bir SmartArt düzenidir. SmartArt nesnesini bir slayta eklerken [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` değerini kullanın. Bu örnek, görüntü yer tutucuları içeren bir diyagramı kaydeder; yer tutuculara görüntü doldurmaz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eski Diyagramları Şekil Gruplarına Dönüştürmek**

Mevcut bir sunumu modernleştirirken, PowerPoint 97–2003'te oluşturulmuş bir organizasyon şemasını güncellemeniz gerekebilir. Aspose.Slides bu eski diyagramları [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/) nesneleri olarak temsil eder. Bir diyagramı, bireysel görsel öğeleri düzenleyebilmek için şekil grubuna dönüştürmek amacıyla [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) kullanın. Ayrıntılar için [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) bölümüne bakın.

Dönüştürme, orijinal diyagramı kaldırmadan şekil koleksiyonuna yeni bir grup ekler. Başarılı dönüşümden sonra, yinelenen içerikten kaçınmak için orijinali [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) ile kaldırın. Şekil ekleme ve kaldırma işlemleri yinelemeyi bozmasın diye, dönüştürmeden önce eski diyagramları bir listeye toplayın.

Aşağıdaki örnek bir sunumu açar, her slaytı tarar, diyagramları şekil gruplarına dönüştürür ve güncellenen sunumu PPTX olarak kaydeder.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaydedilen sunum, dönüştürülmüş eski diyagramların yerine düzenlenebilir şekil grupları içerir; yanlarında orijinal diyagram kalmaz. PPTX dosyasını PowerPoint'te açarak her grup içindeki metin, dolgu veya konum gibi bireysel öğeleri düzenleyebilirsiniz.

## **SSS**

**SmartArt, RTL dilleri için yansıtma veya ters çevirmeyi destekliyor mu?**

Evet. Seçilen SmartArt düzeni ters çevirmeyi desteklediğinde, [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) yöntemi diyagram yönünü soldan sağa’dan sağdan sola veya geri değiştirebilir.

**SmartArt'ı aynı slayta ya da başka bir sunuma biçimlendirmeyi koruyarak nasıl kopyalayabilirim?**

[SmartArt şekli kopyala](/slides/tr/androidjava/shape-manipulations/) ile [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) kullanabilir veya SmartArt içeren tüm slaytı [tüm slaytı kopyala](/slides/tr/androidjava/clone-slides/) ile klonlayabilirsiniz. Her iki yöntem de boyut, konum ve biçimlendirmeyi korur.

**SmartArt'ı önizleme veya web dışa aktarma için raster görüntüye nasıl render edebilirim?**

[Slaytı render et](/slides/tr/androidjava/convert-powerpoint-to-png/) veya tüm sunumu PNG veya JPEG olarak dışa aktarın. SmartArt slaytın bir parçası olarak render edilir.

**Bir slaytta birden fazla SmartArt nesnesi varsa belirli birini nasıl bulabilirim?**

SmartArt şekline ayırt edici bir alternatif metin veya ad atamak için [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) veya [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) kullanın, bu değeri [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) içinde arayın ve ardından eşleşen şeklin bir [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/) olduğunu kontrol edin.