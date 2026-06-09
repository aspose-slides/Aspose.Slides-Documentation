---
title: Android'de Sunumlarda SmartArt Şekil Düğümlerini Yönetme
linktitle: SmartArt Şekil Düğümü
type: docs
weight: 30
url: /tr/androidjava/manage-smartart-shape-node/
keywords:
- SmartArt düğümü
- alt düğüm
- düğüm ekle
- düğüm konumu
- düğüm erişimi
- düğüm kaldırma
- özel konum
- yardımcı düğüm
- dolgu formatı
- düğüm renderlama
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PPT ve PPTX dosyalarındaki SmartArt şekil düğümlerini yönetin. Sunumlarınızı kolaylaştırmak için net Java kod örnekleri ve ipuçları alın."
---
## **Genel Bakış**

PowerPoint sunumlarındaki SmartArt grafikleri, metin içeren ve diyagramın yapısını tanımlayan düğümler aracılığıyla düzenlenir. Aspose.Slides, bu SmartArt düğümleriyle programlı olarak çalışmanıza olanak tanır: yeni düğümler ve alt düğümler ekleyebilir, alt düğümleri belirli bir konuma ekleyebilir, mevcut düğümlere erişebilir ve metin, seviye ve konumlarını okuyabilirsiniz.

Bu makale, SmartArt şekil düğümlerinin nasıl yönetileceğini açıklar. Düğümlerin nasıl kaldırılacağını, alt düğümlerin indeks veya konuma göre nasıl kullanılacağını, asistan düğümünün normal düğüme nasıl dönüştürüleceğini, SmartArt düğüm şekillerinin konum, boyut ve dönüşünün nasıl ayarlanacağını, düğüm dolgu formatlarının nasıl ayarlanacağını ve bir SmartArt alt düğümü için küçük resim görüntüsü nasıl oluşturulacağını gösterir.

## **SmartArt Düğümü Ekleme**
Aspose.Slides for Android via Java, SmartArt şekillerini en kolay şekilde yönetmek için en basit API'yi sağlamıştır. Aşağıdaki örnek kod, SmartArt şekli içinde düğüm ve alt düğüm eklemeye yardımcı olacaktır.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.  
1. İlk slaytın referansını indeksini kullanarak alın.  
1. İlk slayt içindeki her şekli döngüyle gezinin.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. SmartArt şekli üzerindeki [**NodeCollection**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) içinde [Yeni bir Düğüm Ekle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) ve metni TextFrame içinde ayarlayın.  
1. Şimdi, yeni eklenen [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) Düğümüne bir [**Alt Düğüm**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) ekleyin ve metni TextFrame içinde ayarlayın.  
1. Sunumu kaydedin.

```java
// İstenen sunumu yükle
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // İlk slayt içindeki her şekli dolaş
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
    
            // Üst düğümde yeni alt düğüm ekleme. Koleksiyonun sonuna eklenecek
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

## **Belirli Bir Konumda SmartArt Düğümü Ekleme**
Aşağıdaki örnek kodda, SmartArt şeklinin ilgili düğümlerine ait alt düğümlerin belirli bir konuma nasıl ekleneceği açıklanmıştır.

1. Presentation sınıfının bir örneğini oluşturun.  
1. İlk slaytın referansını indeksini kullanarak alın.  
1. Erişilen slayta bir [**StackedList**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) türünde [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt) şekli ekleyin.  
1. Eklenen SmartArt şeklinin ilk düğümüne erişin.  
1. Seçilen [**Düğüm**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtNode) için konum 2'de bir [**Alt Düğüm**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) ekleyin ve metnini ayarlayın.  
1. Sunumu kaydedin.

```java
// Bir sunum örneği oluşturma
Presentation pres = new Presentation();
try {
    // Sunum slaydına erişme
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape ekle
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // İndeks 0'da bulunan SmartArt düğümüne erişme
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

## **SmartArt Düğümüne Erişme**
Aşağıdaki örnek kod, SmartArt şekli içindeki düğümlere erişmenize yardımcı olacaktır. Lütfen SmartArt'ın LayoutType'ını değiştiremeyeceğinizi unutmayın; bu özellik yalnızca SmartArt şekli eklenirken ayarlanır ve salt okunurdur.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.  
1. İlk slaytın referansını indeksini kullanarak alın.  
1. İlk slayt içindeki her şekli döngüyle gezinin.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. SmartArt Şekli içindeki tüm [**Düğümleri**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt#getAllNodes--) dolaşın.  
1. SmartArt Düğümünün konumu, seviyesi ve Metni gibi bilgileri erişin ve gösterin.

```java
// Presentation sınıfını örnekle
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayt içindeki her şekli dolaş
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
Aşağıdaki örnek kod, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere nasıl erişileceğini gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.  
1. İlk slaytın referansını indeksini kullanarak alın.  
1. İlk slayt içindeki her şekli döngüyle gezinin.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. SmartArt Şekli içindeki tüm [**Düğümleri**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt#getAllNodes--) dolaşın.  
1. Her seçilen SmartArt şekli [**Düğümü**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtNode) için ilgili düğüm içindeki tüm [**Alt Düğümleri**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) dolaşın.  
1. [**Alt Düğüm**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) konumu, seviyesi ve Metni gibi bilgileri erişin ve gösterin.

```java
// Presentation sınıfını örnekle
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayt içindeki her şekli dolaş
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
                // i indeksindeki SmartArt düğümüne erişme
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // i indeksindeki SmartArt düğümündeki alt düğümleri dolaş
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
Bu örnekte, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere belirli bir konumda nasıl erişileceği öğrenilecektir.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. İlk slaytın referansını indeksini kullanarak alın.  
1. Bir [**StackedList**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) türünde SmartArt şekli ekleyin.  
1. Eklenen SmartArt şekline erişin.  
1. Erişilen SmartArt şeklinin indeks 0’daki düğümüne erişin.  
1. **get_Item()** metodunu kullanarak erişilen SmartArt düğümünün konum 1’deki [**Alt Düğümüne**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) erişin.  
1. [**Alt Düğüm**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) konumu, seviyesi ve Metni gibi bilgileri erişin ve gösterin.

```java
// Sunumu oluştur
Presentation pres = new Presentation();
try {
    // İlk slayta erişme
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayta SmartArt şekli ekleme
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // İndeks 0'da SmartArt düğümüne erişme
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
Bu örnekte, SmartArt şekli içindeki düğümlerin nasıl kaldırılacağı öğrenilecektir.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.  
1. İlk slaytın referansını indeksini kullanarak alın.  
1. İlk slayt içindeki her şekli döngüyle gezinin.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) içinde 0’dan fazla düğüm olup olmadığını kontrol edin.  
1. Silinecek SmartArt düğümünü seçin.  
1. Seçilen düğümü [**RemoveNode**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) yöntemiyle kaldırın.  
1. Sunumu kaydedin.

```java
// İstenen sunumu yükle
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // İlk slayt içindeki her şekli dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // İndeks 0'da SmartArt düğümüne erişme
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Seçilen düğümü kaldırma
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

## **Belirli Bir Konumdan SmartArt Düğümünü Kaldırma**
Bu örnekte, SmartArt şekli içindeki düğümlerin belirli bir konumda nasıl kaldırılacağı öğrenilecektir.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.  
1. İlk slaytın referansını indeksini kullanarak alın.  
1. İlk slayt içindeki her şekli döngüyle gezinin.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. İndeks 0’da bulunan SmartArt şekli düğümünü seçin.  
1. Seçilen SmartArt düğümünün 2’den fazla alt düğümü olup olmadığını kontrol edin.  
1. **Position 1** konumundaki düğümü [**RemoveNode**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) yöntemiyle kaldırın.  
1. Sunumu kaydedin.

```java
// İstenen sunumu yükle
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // İlk slayt içindeki her şekli dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof SmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // İndeks 0'da SmartArt düğümüne erişme
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Pozisyon 1'deki alt düğümü kaldırma
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

## **SmartArt Nesnesinde Bir Alt Düğüm İçin Özel Konum Ayarlama**
Artık Aspose.Slides for Android via Java, [SmartArtShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#setX-float-) ve [Y](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#setY-float-) özelliklerini ayarlamayı destekler. Aşağıdaki kod parçacığı, özel SmartArtShape konumu, boyutu ve dönüşünün nasıl ayarlanacağını gösterir; ayrıca yeni düğüm eklemenin tüm düğümlerin konum ve boyutlarının yeniden hesaplanmasına neden olduğunu lütfen unutmayın. Özel konum ayarlarıyla kullanıcı, düğümleri gereksinimlerine göre ayarlayabilir.

```java
// Presentation sınıfını örnekle
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt şekline yeni konuma taşı
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

    // SmartArt şeklinin dönüşümünü değiştir
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Bir Yardımcı Düğümü Kontrol Etme**
{{% alert color="primary" %}} 

Bu makalede, Aspose.Slides for Android via Java kullanılarak sunum slaytlarına programlı olarak eklenen SmartArt şekillerinin özelliklerini daha derinlemesine inceleyeceğiz.

{{% /alert %}} 

İnceleme yapacağımız kaynak SmartArt şekli aşağıdaki tablodadır.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Şekil: Slayttaki Kaynak SmartArt şekli**|

Aşağıdaki örnek kodda, SmartArt düğüm koleksiyonundaki **Yardımcı Düğümleri** (Assistant Nodes) tanımlama ve bunları değiştirme konuları incelenecektir.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.  
1. İkinci slaytın referansını indeksini kullanarak alın.  
1. İlk slayt içindeki her şekli döngüyle gezinin.  
1. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.  
1. SmartArt şekli içindeki tüm düğümleri dolaşın ve bunların [**Yardımcı Düğümler**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) olup olmadığını kontrol edin.  
1. Yardımcı Düğümün durumunu normal düğüm olarak değiştirin.  
1. Sunumu kaydedin.

```java
// Sunum örneği oluşturma
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // İlk slayt içindeki her şekli dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt şeklinin tüm düğümlerinde dolaşma
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Düğümün Yardımcı düğüm olup olmadığını kontrol et
                if (node.isAssistant()) 
                {
                    // Yardımcı düğümü false yap ve normal düğüm haline getir
                    node.isAssistant();
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
|**Şekil: Slayttaki SmartArt şeklinde Değiştirilen Yardımcı Düğümler**|

## **Bir Düğümün Dolgu Formatını Ayarlama**
Aspose.Slides for Android via Java, özel SmartArt şekilleri eklemeyi ve dolgu formatlarını ayarlamayı mümkün kılar. Bu makale, SmartArt şekillerinin nasıl oluşturulacağını, erişileceğini ve dolgu formatının nasıl ayarlanacağını Aspose.Slides for Android via Java kullanarak açıklar.

Lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaytın referansını indeksini kullanarak alın.  
1. [**LayoutType**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) ayarlayarak bir [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) şekli ekleyin.  
1. SmartArt şekli düğümleri için [**FillFormat**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#getFillFormat--) ayarlayın.  
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```java
// Sunumu oluştur
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

## **Bir SmartArt Alt Düğümünün Küçük Resmini Oluşturma**
Geliştiriciler, aşağıdaki adımları izleyerek bir SmartArt alt düğümünün küçük resmini oluşturabilir:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. [SmartArt Ekle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
1. Bir düğümün referansını indeksini kullanarak alın.  
1. Küçük resim görüntüsünü alın.  
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekle
Presentation pres = new Presentation();
try {
    // SmartArt ekle
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Düğümün referansını indeksini kullanarak al
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

Evet. SmartArt normal bir şekil gibi ele alınır, bu nedenle [standart animasyonlar](/slides/tr/androidjava/shape-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulayabilir ve zamanlamayı ayarlayabilirsiniz. Gerektiğinde SmartArt düğümlerindeki şekilleri de canlandırabilirsiniz.

**Bir slaytta iç ID'si bilinmeyen belirli bir SmartArt'ı nasıl güvenilir bir şekilde bulabilirim?**

[Alternatif metin](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getAlternativeText--) kullanarak atama ve arama yapın. SmartArt üzerine belirgin bir AltText ayarlamak, iç tanımlayıcılara güvenmeden programatik olarak bulmanızı sağlar.

**SmartArt görünümü, sunumu PDF'ye dönüştürürken korunur mu?**

Evet. Aspose.Slides, [PDF dışa aktarımı](/slides/tr/androidjava/convert-powerpoint-to-pdf/) sırasında SmartArt'ı yüksek görsel doğrulukla işler, düzeni, renkleri ve efektleri korur.

**Tüm SmartArt'ın (ön izlemeler veya raporlar için) bir görüntüsünü çıkarabilir miyim?**

Evet. SmartArt şekli, [raster formatlarda](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) veya [SVG](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) olarak render edilebilir; bu, küçük resimler, raporlar veya web kullanımı için ölçeklenebilir vektör çıktısı sağlar.