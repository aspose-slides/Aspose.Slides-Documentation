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
- düğüm erişimi
- düğüm kaldırma
- özel konum
- asistan düğümü
- dolgu biçimi
- düğüm renderleme
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PPT ve PPTX dosyalarındaki SmartArt şekil düğümlerini yönetin. Sunumlarınızı kolaylaştırmak için net kod örnekleri ve ipuçları edinin."
---
## **Genel Bakış**

PowerPoint sunumlarındaki SmartArt grafikleri, metin içeren ve diyagramın yapısını tanımlayan düğümler aracılığıyla düzenlenir. Aspose.Slides, bu SmartArt düğümleriyle programlı olarak çalışmanıza olanak tanır: yeni düğümler ve alt düğümler ekleyebilir, alt düğümleri belirli bir konuma ekleyebilir, mevcut düğümlere erişebilir ve metinlerini, seviyelerini ve konumlarını okuyabilirsiniz.

Bu makale, SmartArt şekil düğümlerinin nasıl yönetileceğini açıklar. Düğümlerin nasıl kaldırılacağını, alt düğümlerle indeks veya konuma göre nasıl çalışılacağını, asistan düğümünün normal düğüme nasıl dönüştürüleceğini, SmartArt düğüm şekillerinin konum, boyut ve dönüşümünün nasıl ayarlanacağını, düğüm dolgu biçimlerinin nasıl ayarlanacağını ve bir SmartArt alt düğümü için küçük resim görüntüsü nasıl oluşturulacağını gösterir.

## **SmartArt Düğümü Ekle**
Aspose.Slides for Java, SmartArt şekillerini en kolay şekilde yönetmek için en basit API'yi sağlamıştır. Aşağıdaki örnek kod, SmartArt şekli içinde düğüm ve alt düğüm eklemenize yardımcı olacaktır.

1. SmartArt Şekli ile sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İlk slaytın referansını indeksini kullanarak edinin.  
1. İlk slayt içindeki tüm şekilleri dolaşın.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. SmartArt şekli içinde yeni bir [Yeni bir Düğüm Ekle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**NodeCollection**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt#getAllNodes--) ekleyin ve metni TextFrame içinde ayarlayın.  
1. Şimdi, yeni eklenen [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) Düğümüne bir [**Child Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) [Ekle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) ve metni TextFrame içinde ayarlayın.  
1. Sunumu Kaydedin.

```java
// İstenen sunumu yükle
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // İlk slayt içindeki tüm şekillerde dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt tipi olup olmadığını kontrol et
        if (shape instanceof SmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            SmartArt smart = (SmartArt) shape;
    
            // Yeni bir SmartArt düğümü ekleme
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Metin ekleme
            TemNode.getTextFrame().setText("Test");
    
            // Ana düğümde yeni bir alt düğüm ekleme. Koleksiyonun sonuna eklenecek
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

## **Belirli Bir Konumda SmartArt Düğümü Ekle**
Aşağıdaki örnek kodda, SmartArt şeklinin ilgili düğümlerine ait alt düğümlerin belirli bir konuma nasıl ekleneceğini açıkladık.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İlk slaytın referansını indeksini kullanarak edinin.  
1. Erişilen slayta [**StackedList**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtLayoutType#StackedList) türünde bir [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt) şekli ekleyin.  
1. Eklenen SmartArt şekli içindeki ilk düğüme erişin.  
1. Şimdi, seçilen [**Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtNode) için konum 2'de bir [**Child Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) ekleyin ve metnini ayarlayın.  
1. Sunumu Kaydedin.

```java
// Sunum örneği oluşturma
Presentation pres = new Presentation();
try {
    // Sunum slaytına erişme
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape ekleme
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // İndeks 0'da bulunan SmartArt düğümüne erişme
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Üst düğümde konum 2'de yeni alt düğüm ekleme
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Metin ekleme
    chNode.getTextFrame().setText("Sample Text Added");

    // Sunumu kaydetme
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt Düğümüne Erişme**
Aşağıdaki örnek kod, SmartArt şekli içindeki düğümlere erişmenize yardımcı olacaktır. Lütfen SmartArt'ın LayoutType'ını değiştirmenin mümkün olmadığını, bunun sadece okunabilir olduğunu ve yalnızca SmartArt şekli eklendiğinde ayarlandığını unutmayın.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli ile sunumu yükleyin.  
1. İlk slaytın referansını indeksini kullanarak edinin.  
1. İlk slayt içindeki tüm şekilleri dolaşın.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. SmartArt Şekli içindeki tüm [**Nodes**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt#getAllNodes--) dolaşın.  
1. SmartArt Düğümünün konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```java
// Sunum Sınıfını Örnekle
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayt içindeki tüm şekillerde dolaş
    for (IShape shape : slide.getShapes()) 
    {
        // Şeklin SmartArt tipi olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt içindeki tüm düğümlerde dolaş
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // i indeksindeki SmartArt düğümüne erişme
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // SmartArt düğüm parametrelerini yazdırma
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt Alt Düğümüne Erişme**
Aşağıdaki örnek kod, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere erişmenize yardımcı olacaktır.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli ile sunumu yükleyin.  
1. İlk slaytın referansını indeksini kullanarak edinin.  
1. İlk slayt içindeki tüm şekilleri dolaşın.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. SmartArt Şekli içindeki tüm [**Nodes**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArt#getAllNodes--) dolaşın.  
1. Her seçilen SmartArt şekli [**Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtNode) için, ilgili düğüm içindeki tüm [**Child Nodes**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtNode#getChildNodes--) dolaşın.  
1. [**Child Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```java
// Sunum Sınıfını Örnekle
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayt içindeki tüm şekillerde dolaş
    for (IShape shape : slide.getShapes()) 
    {
        // Şeklin SmartArt tipi olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt içindeki tüm düğümlerde dolaş
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // i indeksindeki SmartArt düğümüne erişme
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // i indeksindeki SmartArt düğümündeki alt düğümlerde dolaşma
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // SmartArt düğümündeki alt düğüme erişme
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // SmartArt alt düğüm parametrelerini yazdırma
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Belirli Bir Konumda SmartArt Alt Düğümüne Erişme**
Bu örnekte, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere belirli bir konumda nasıl erişileceğini öğreneceğiz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. İlk slaytın referansını indeksini kullanarak edinin.  
1. [**StackedList**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtLayoutType#StackedList) türünde bir SmartArt şekli ekleyin.  
1. Eklenen SmartArt şekline erişin.  
1. Erişilen SmartArt şekli için indeks 0’daki düğüme erişin.  
1. Şimdi, erişilen SmartArt düğümünde konum 1’deki [**Child Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) öğesine **get_Item()** yöntemiyle erişin.  
1. [**Child Node**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```java
// Sunumu örnekle
Presentation pres = new Presentation();
try {
    // İlk slayta erişme
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayta SmartArt şekli ekleme
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // İndeks 0'da bulunan SmartArt düğümüne erişme
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Üst düğümde konum 1'deki alt düğüme erişme
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // SmartArt alt düğüm parametrelerini yazdırma
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt Düğümünü Kaldırma**
Bu örnekte, SmartArt şekli içindeki düğümleri nasıl kaldıracağınızı öğreneceksiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli ile sunumu yükleyin.  
1. İlk slaytın referansını indeksini kullanarak edinin.  
1. İlk slayt içindeki tüm şekilleri dolaşın.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. SmartArt'ın 0’dan fazla düğümü olup olmadığını kontrol edin.  
1. Silinecek SmartArt düğümünü seçin.  
1. Seçilen düğümü [**RemoveNode**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) yöntemiyle kaldırın.  
1. Sunumu Kaydedin.

```java
// İstenen sunumu yükle
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // İlk slayt içindeki tüm şekillerde dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt tipi olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // İndeks 0'da bulunan SmartArt düğümüne erişme
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Seçilen düğümü kaldırma
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Sunumu Kaydet
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Belirli Bir Konumdan SmartArt Düğümünü Kaldırma**
Bu örnekte, SmartArt şekli içinde belirli bir konumdaki düğümleri nasıl kaldıracağınızı öğreneceksiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli ile sunumu yükleyin.  
1. İlk slaytın referansını indeksini kullanarak edinin.  
1. İlk slayt içindeki tüm şekilleri dolaşın.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. İndeks 0’daki SmartArt şekli düğümünü seçin.  
1. Şimdi, seçilen SmartArt düğümünün 2’den fazla alt düğümü olup olmadığını kontrol edin.  
1. **Position 1** konumundaki düğümü [**RemoveNode**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) yöntemiyle kaldırın.  
1. Sunumu Kaydedin.

```java
// İstenen sunumu yükle
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // İlk slayt içindeki tüm şekillerde dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt tipi olup olmadığını kontrol et
        if (shape instanceof SmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // İndeks 0'da bulunan SmartArt düğümüne erişme
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Pozisyon 1'deki alt düğümü kaldırma
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Sunumu Kaydet
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt Nesnesindeki Bir Alt Düğüm İçin Özel Konum Ayarlama**
Artık Aspose.Slides for Java, [SmartArtShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#setX-float-) ve [Y](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#setY-float-) özelliklerini ayarlamayı desteklemektedir. Aşağıdaki kod parçacığı, özel SmartArtShape konumu, boyutu ve dönüşümünün nasıl ayarlanacağını gösterir; ayrıca yeni düğüm eklemenin tüm düğümlerin konum ve boyutlarını yeniden hesapladığını unutmayın. Özel konum ayarlarıyla kullanıcı, düğümleri gereksinimlerine göre konumlandırabilir.

```java
// Sunum Sınıfını Örnekle
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

    // SmartArt şeklinin döndürmesini değiştir
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Bir Asistan Düğümünü Kontrol Etme**
{{% alert color="primary" %}} 

Bu makalede, Aspose.Slides for Java kullanarak sunum slaytlarına programlı olarak eklenen SmartArt şekillerinin özelliklerini daha ayrıntılı olarak inceleyeceğiz.

{{% /alert %}} 

Farklı bölümlerde inceleme yapacağımız aşağıdaki kaynak SmartArt şekli kullanılacaktır.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Şekil: Slayttaki Kaynak SmartArt şekli**|

Aşağıdaki örnek kodda, SmartArt düğüm koleksiyonunda **Assistant Nodes** (Asistan Düğümler) nasıl tanımlanır ve nasıl değiştirilir incelenecektir.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli ile sunumu yükleyin.  
1. İkinci slaytın referansını indeksini kullanarak edinin.  
1. İlk slayt içindeki tüm şekilleri dolaşın.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. SmartArt şekli içindeki tüm düğümleri dolaşın ve bunların [**Assistant Nodes**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtNode#isAssistant--) olup olmadığını kontrol edin.  
1. Asistan Düğümünün durumunu normal düğüm olarak değiştirin.  
1. Sunumu Kaydedin.

```java
// Sunum örneği oluşturma
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // İlk slayt içindeki tüm şekillerde dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt tipi olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt şeklinin tüm düğümlerinde dolaş
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Düğümün Asistan düğümü olup olmadığını kontrol et
                if (node.isAssistant()) 
                {
                    // Asistan düğümünü false olarak ayarlama ve normal düğüm haline getirme
                    node.isAssistant();
                }
            }
        }
    }
    
    // Sunumu Kaydet
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Şekil: Slayt içinde SmartArt şekline eklenen Asistan Düğümlerinin Değiştirilmesi**|

## **Bir Düğümün Dolgu Biçimini Ayarlama**
Aspose.Slides for Java, özel SmartArt şekilleri eklemeyi ve dolgu biçimlerini ayarlamayı mümkün kılar. Bu makale, SmartArt şekilleri oluşturmayı, erişmeyi ve dolgu biçimlerini Aspose.Slides for Java kullanarak ayarlamayı açıklar.

Lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksini kullanarak edinin.  
1. [SmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArt) şekli ekleyin ve [**LayoutType**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) ayarlayın.  
1. SmartArt şekil düğümleri için [**FillFormat**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape#getFillFormat--) ayarlayın.  
1. Değiştirilen sunumu PPTX dosyası olarak yazın.

```java
// Sunumu örnekle
Presentation pres = new Presentation();
try {
    // Slayta erişme
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

## **SmartArt Alt Düğümünün Küçük Resmini Oluşturma**
Geliştiriciler aşağıdaki adımları izleyerek bir SmartArt alt düğümünün küçük resmini oluşturabilir:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. [SmartArt Ekle](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
1. Bir düğümün referansını indeksini kullanarak edinin.  
1. Küçük resim görüntüsünü alın.  
1. Küçük resim görüntüsünü istenen herhangi bir görüntü formatında kaydedin.

```java
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

## **SSS**

**SmartArt animasyonu destekleniyor mu?**

Evet. SmartArt normal bir şekil olarak ele alınır, bu yüzden [standart animasyonları](/slides/tr/java/shape-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulayabilir ve zamanlamayı ayarlayabilirsiniz. Gerektiğinde SmartArt düğümleri içindeki şekiller de animasyon eklenebilir.

**İç kimliği bilinmeyen belirli bir SmartArt'ı slaytta nasıl güvenilir bir şekilde bulabilirim?**

[Alternatif metin](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getAlternativeText--) kullanarak atama yapın ve ona göre arama yapın. SmartArt üzerine belirgin bir AltText ayarlamak, dahili tanımlayıcılara güvenmeden programlı olarak bulmanızı sağlar.

**Sunumu PDF'ye dönüştürürken SmartArt görünümü korunacak mı?**

Evet. Aspose.Slides, [PDF dışa aktarımı](/slides/tr/java/convert-powerpoint-to-pdf/) sırasında SmartArt'ı yüksek görsel doğrulukla render eder, düzeni, renkleri ve efektleri korur.

**Tüm SmartArt'ın (ön izlemeler veya raporlar için) bir görüntüsünü çıkarabilir miyim?**

Evet. SmartArt şekli, [raster formatlarına](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getImage-int-float-float-) ya da [SVG](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) formatına render edilebilir; bu da onu küçük resimler, raporlar veya web kullanımı için ölçeklenebilir vektörel çıktı olarak uygun kılar.