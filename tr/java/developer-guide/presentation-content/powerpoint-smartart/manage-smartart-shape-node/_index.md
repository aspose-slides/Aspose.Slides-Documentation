---
title: Java Kullanarak Sunumlarda SmartArt Şekil Düğümlerini Yönetme
linktitle: SmartArt Şekil Düğümü
type: docs
weight: 30
url: /tr/java/manage-smartart-shape-node/
keywords:
- SmartArt düğümü
- alt düğüm
- düğüm ekle
- düğüm konumu
- düğüme eriş
- düğüm kaldır
- özel konum
- yardımcı düğüm
- dolgu biçimi
- düğüm render
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PPT ve PPTX’de SmartArt şekil düğümlerini yönetin. Sunumlarınızı kolaylaştırmak için net kod örnekleri ve ipuçları alın."
---
## **Overview**

PowerPoint sunumlarındaki SmartArt grafikler, metin içeren ve diyagramın yapısını tanımlayan düğümler aracılığıyla düzenlenir. Aspose.Slides, bu SmartArt düğümleriyle programlı olarak çalışmanıza olanak tanır: yeni düğümler ve alt düğümler ekleyebilir, belirli bir konuma alt düğüm ekleyebilir, mevcut düğümlere erişebilir ve metin, seviye ve konumlarını okuyabilirsiniz.

Bu makale, SmartArt şekil düğümlerinin nasıl yönetileceğini açıklar. Düğüm kaldırma, indeks ya da konuma göre alt düğüm işleme, bir yardımcı düğümü normal düğüme dönüştürme, SmartArt düğüm şekillerinin konum, boyut ve döndürülmesini ayarlama, düğüm dolgu formatlarını ayarlama ve bir SmartArt alt düğümü için küçük resim oluşturma konularını gösterir.

## **Add a SmartArt Node**
Aspose.Slides for Java, SmartArt şekillerini en kolay şekilde yönetmek için en basit API’yi sunar. Aşağıdaki örnek kod, SmartArt şekli içinde düğüm ve alt düğüm eklemeye yardımcı olacaktır.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. İlk slaytın referansını indeksini kullanarak alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.
1. SmartArt şeklinin [**NodeCollection**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt#getAllNodes--) içinde [Add a new Node](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) ekleyin ve TextFrame içinde metni ayarlayın.
1. Şimdi, yeni eklenen [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) Düğümüne bir [**Child Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) ekleyin ve TextFrame içinde metni ayarlayın.
1. Sunumu kaydedin.

```java
import com.aspose.slides.*;

// İstenilen sunumu yükleyin
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // İlk slayttaki her şekli dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof SmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            SmartArt smart = (SmartArt) shape;
    
            // Yeni bir SmartArt Düğümü ekleme
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Metin ekleme
            TemNode.getTextFrame().setText("Test");
    
            // Üst düğümde yeni bir alt düğüm ekleme. Koleksiyonun sonuna eklenecek
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Metin ekleme
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Sunumu kaydetme
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add a SmartArt Node at a Specific Position**
Aşağıdaki örnek kodda, SmartArt şeklinin ilgili düğümlerine ait alt düğümlerin belirli bir konuma nasıl ekleneceği açıklanmıştır.

1. Presentation sınıfının bir örneğini oluşturun.
1. İlk slaytın referansını indeksini kullanarak alın.
1. Erişilen slayta bir [**StackedList**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtLayoutType#StackedList) türünde [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt) şekli ekleyin.
1. Eklenen SmartArt şeklinin ilk düğümüne erişin.
1. Seçilen [**Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtNode) için konum 2’de bir [**Child Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) ekleyin ve metnini ayarlayın.
1. Sunumu kaydedin.

```java
import com.aspose.slides.*;

// Bir sunum örneği oluşturma
Presentation pres = new Presentation();
try {
    // Sunum slaydına eriş
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape ekle
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // İndeks 0'da bulunan SmartArt düğümüne eriş
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Üst düğümde konum 2'de yeni alt düğüm ekleme
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Metin ekle
    chNode.getTextFrame().setText("Sample Text Added");

    // Sunumu kaydet
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Access a SmartArt Node**
Aşağıdaki örnek kod, SmartArt şekli içindeki düğümlere erişmenize yardımcı olur. Lütfen SmartArt’ın LayoutType özelliğinin yalnızca okunabilir olduğunu ve yalnızca SmartArt şekli eklenirken ayarlandığını unutmayın.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. İlk slaytın referansını indeksini kullanarak alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.
1. SmartArt Şekli içindeki tüm [**Nodes**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt#getAllNodes--) arasında dolaşın.
1. SmartArt Düğümünün konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```java
import com.aspose.slides.*;

// Presentation sınıfını örnekle
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayttaki her şekli dolaş
    for (IShape shape : slide.getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt içindeki tüm düğümleri dolaş
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // i indeksindeki SmartArt düğümüne eriş
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // SmartArt düğüm parametrelerini yazdır
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Access a SmartArt Child Node**
Aşağıdaki örnek kod, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere erişmenize yardımcı olur.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. İlk slaytın referansını indeksini kullanarak alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.
1. SmartArt Şekli içindeki tüm [**Nodes**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt#getAllNodes--) arasında dolaşın.
1. Her seçilen SmartArt şekli [**Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtNode) için ilgili düğüm içindeki tüm [**Child Nodes**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtNode#getChildNodes--) arasında dolaşın.
1. [**Child Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```java
import com.aspose.slides.*;

// Presentation sınıfını örnekle
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayttaki her şekli dolaş
    for (IShape shape : slide.getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt içindeki tüm düğümleri dolaş
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // i indeksindeki SmartArt düğümüne eriş
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // i indeksindeki SmartArt düğümündeki alt düğümleri dolaş
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // SmartArt düğümündeki alt düğüme eriş
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // SmartArt alt düğüm parametrelerini yazdır
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Access a SmartArt Child Node at a Specific Position**
Bu örnekte, SmartArt şeklinin ilgili düğümlerine ait alt düğümlerin belirli bir konumda nasıl erişileceğini öğreneceksiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İlk slaytın referansını indeksini kullanarak alın.
1. Bir [**StackedList**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtLayoutType#StackedList) türünde SmartArt şekli ekleyin.
1. Eklenen SmartArt şekline erişin.
1. Erişilen SmartArt şeklinin indeks 0’da bulunan düğümüne erişin.
1. Şimdi, **get_Item()** metodunu kullanarak erişilen SmartArt düğümünde konum 1’deki [**Child Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) öğesine erişin.
1. [**Child Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```java
import com.aspose.slides.*;

// Sunumu örnekle
Presentation pres = new Presentation();
try {
    // İlk slayta eriş
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayta SmartArt şekli ekleme
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // İndeks 0'da bulunan SmartArt düğümüne eriş
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Üst düğümde konum 1'deki alt düğüme eriş
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // SmartArt alt düğüm parametrelerini yazdır
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remove a SmartArt Node**
Bu örnekte, SmartArt şekli içindeki düğümlerin nasıl kaldırılacağını öğreneceksiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. İlk slaytın referansını indeksini kullanarak alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.
1. [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) içinde 0’dan fazla düğüm olup olmadığını kontrol edin.
1. Silinecek SmartArt düğümünü seçin.
1. Şimdi, seçilen düğümü [**RemoveNode**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) yöntemiyle kaldırın.
1. Sunumu kaydedin.

```java
import com.aspose.slides.*;

// İstenen sunumu yükle
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // İlk slayttaki her şekli dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // İndeks 0'da bulunan SmartArt düğümüne eriş
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Seçilen düğümü kaldır
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Sunumu kaydet
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remove a SmartArt Node from a Specific Position**
Bu örnekte, SmartArt şekli içindeki düğümlerin belirli bir konumda nasıl kaldırılacağını öğreneceksiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. İlk slaytın referansını indeksini kullanarak alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.
1. İndeks 0’da bulunan SmartArt şekli düğümünü seçin.
1. Şimdi, seçilen SmartArt düğümünün 2’den fazla alt düğümü olup olmadığını kontrol edin.
1. Şimdi, **Position 1** konumundaki düğümü [**RemoveNode**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) yöntemiyle kaldırın.
1. Sunumu kaydedin.

```java
import com.aspose.slides.*;

// İstenen sunumu yükle
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // İlk slayttaki her şekli dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof SmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // İndeks 0'da bulunan SmartArt düğümüne eriş
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Pozisyon 1'deki alt düğümü kaldır
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Sunumu kaydet
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set a Custom Position for a Child Node in a SmartArt Object**
Aspose.Slides for Java artık [SmartArtShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtShape) için [X](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#setX-float-) ve [Y](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#setY-float-) özelliklerini ayarlamayı destekliyor. Aşağıdaki kod örneği, özel SmartArtShape konumu, boyutu ve döndürülmesini nasıl ayarlayacağınızı gösterir; ayrıca yeni düğüm eklemenin tüm düğümlerin konum ve boyutlarının yeniden hesaplanmasına yol açtığını lütfen unutmayın. Özel konum ayarlarıyla kullanıcı, düğümleri ihtiyaçlarına göre konumlandırabilir.

```java
import com.aspose.slides.*;

// Presentation sınıfını örnekle
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt şekli yeni konuma taşı
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // SmartArt şeklinin genişliklerini değiştir
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // SmartArt şeklinin yüksekliğini değiştir
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // SmartArt şeklinin döndürülmesini değiştir
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Check an Assistant Node**
{{% alert color="info" %}} 

Bu makalede, Aspose.Slides for Java kullanarak sunum slaytlarına programlı olarak eklenen SmartArt şekillerinin özelliklerini daha ayrıntılı inceleyeceğiz.

{{% /alert %}} 

Araştırmamızda farklı bölümlerde kullanacağımız aşağıdaki kaynak SmartArt şekilini kullanacağız.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: Source SmartArt shape in slide**|

Aşağıdaki örnek kodda, SmartArt düğüm koleksiyonundaki **Assistant Nodes** nasıl tanımlanır ve değiştirildiği incelenecek.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt şekli içeren sunumu yükleyin.
1. İkinci slaytın referansını indeksini kullanarak alın.
1. İlk slayt içindeki her şekli dolaşın.
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.
1. SmartArt şekli içindeki tüm düğümler arasında dolaşın ve bunların [**Assistant Nodes**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtNode#isAssistant--) olup olmadığını kontrol edin.
1. Assistant Node durumunu normal düğüme değiştirin.
1. Sunumu kaydedin.

```java
import com.aspose.slides.*;

// Sunum örneği oluşturma
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // İlk slayttaki her şekli dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt şeklinin tüm düğümlerinde dolaş
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Düğümün Yardımcı düğüm olup olmadığını kontrol et
                if (node.isAssistant()) 
                {
                    // Yardımcı düğümünü false yap ve normal düğüm haline getir
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // Sunumu kaydet
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure: Assistant Nodes Changed in SmartArt shape inside slide**|

## **Set a Node's Fill Format**
Aspose.Slides for Java, özel SmartArt şekilleri eklemeyi ve bunların dolgu formatını ayarlamayı mümkün kılar. Bu makale, SmartArt şekilleri oluşturma, erişme ve dolgu formatını ayarlama konularını Aspose.Slides for Java kullanarak açıklar.

Lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Bir slaytın referansını indeksini kullanarak alın.
1. [**LayoutType**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) ayarlayarak bir [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) şekli ekleyin.
1. SmartArt şekli düğümleri için [**FillFormat**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#getFillFormat--) ayarlayın.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunumu örnekle
Presentation pres = new Presentation();
try {
    // Slayta eriş
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt şekli ve düğümler ekleme
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Düğüm dolgu rengini ayarlama
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Sunumu kaydet
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generate a Thumbnail of a SmartArt Child Node**
Geliştiriciler, aşağıdaki adımları izleyerek bir SmartArt’ın Alt Düğümünün thumbnail’ını oluşturabilir:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. [Add SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) ekleyin.
1. Bir düğümün referansını indeksini kullanarak edinin.
1. Thumbnail görüntüsünü alın.
1. Thumbnail görüntüsünü istenen herhangi bir resim formatında kaydedin.

```java
import com.aspose.slides.*;

// PPTX dosyasını temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation();
try {
    // SmartArt ekle 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Bir düğümün referansını indeksini kullanarak al  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Küçük resmi al
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Küçük resmi kaydet
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Is SmartArt animation supported?

Evet. SmartArt normal bir şekil olarak ele alındığından, [standart animasyonları](/slides/tr/java/shape-animation/) (giriş, çıkış, vurgulama, hareket yolları) uygulayabilir ve zamanlamayı ayarlayabilirsiniz. Gerektiğinde SmartArt düğümleri içindeki şekilleri de animasyon yapabilirsiniz.

### How can I reliably locate a specific SmartArt on a slide if its internal ID is unknown?

[Alternative text](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getAlternativeText--) kullanarak atama yapın ve arayın. SmartArt üzerine ayırt edici bir AltText belirlemek, iç kimliklere güvenmeden programatik olarak bulmanızı sağlar.

### Will the SmartArt appearance be preserved when converting the presentation to PDF?

Evet. Aspose.Slides, [PDF export](/slides/tr/java/convert-powerpoint-to-pdf/) sırasında SmartArt’ı yüksek görsel doğrulukla işler, düzeni, renkleri ve efektleri korur.

### Can I extract an image of the entire SmartArt (for previews or reports)?

Evet. SmartArt şekli, [raster formatlarına](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getImage-int-float-float-) veya [SVG](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) formatına render edilebilir; bu da küçük resimler, raporlar veya web kullanımı için ölçeklenebilir vektör çıktısı sağlar.