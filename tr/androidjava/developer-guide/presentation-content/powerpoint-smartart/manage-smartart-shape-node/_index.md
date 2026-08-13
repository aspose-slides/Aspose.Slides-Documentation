---
title: Android'de Sunumlarda SmartArt Şekil Düğümlerini Yönetin
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
- düğüm sil
- özel konum
- asistan düğüm
- doldurma biçimi
- düğüm renderleme
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PPT ve PPTX'teki SmartArt şekil düğümlerini yönetin. Sunumlarınızı kolaylaştırmak için net Java kod örnekleri ve ipuçları alın."
---
## **Genel Bakış**

PowerPoint sunumlarındaki SmartArt grafikler, metin içeren ve diyagramın yapısını tanımlayan düğümler aracılığıyla düzenlenir. Aspose.Slides, bu SmartArt düğümleriyle programlı olarak çalışmanızı sağlar: yeni düğümler ve alt düğümler ekleme, alt düğümleri belirli bir konuma yerleştirme, mevcut düğümlere erişme ve metinlerini, seviyelerini ve konumlarını okuma.

Bu makale, SmartArt şekil düğümlerinin nasıl yönetileceğini açıklar. Düğümlerin nasıl kaldırılacağını, alt düğümlerle indeks ya da konuma göre nasıl çalışılacağını, bir asistan düğümünün normal düğüme nasıl dönüştürüleceğini, SmartArt düğüm şekillerinin konum, boyut ve dönüşünün nasıl ayarlanacağını, düğüm doldurma biçimlerinin nasıl ayarlanacağını ve bir SmartArt düğümü için küçük resim görüntüsü nasıl oluşturulacağını gösterir.

## **SmartArt Düğümü Ekle**

Aspose.Slides for Android via Java, SmartArt şekillerini en kolay şekilde yönetmek için en basit API'yi sunar. Aşağıdaki örnek kod, SmartArt şekli içinde düğüm ve alt düğüm eklemenize yardımcı olacaktır.

1. SmartArt Şekli içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İlk slaytın referansını indeksini kullanarak elde edin.
3. İlk slayttaki tüm şekiller arasında dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.
5. SmartArt şeklinde [Yeni Bir Düğüm Ekle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**NodeCollection**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) içinde ve metni TextFrame'e ayarlayın.
6. Şimdi, yeni eklenen [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) Düğümüne bir [**Alt Düğüm**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) [Ekle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) ve metni TextFrame'e ayarlayın.
7. Sunumu kaydedin.

```java
import com.aspose.slides.*;

// İstenen sunumu yükleyin
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // İlk slayttaki tüm şekiller arasında dolaşın
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol edin
        if (shape instanceof SmartArt) 
        {
            // Şekli SmartArt tipine dönüştürün
            SmartArt smart = (SmartArt) shape;
    
            // Yeni bir SmartArt düğümü ekleme
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

## **Belirli Bir Konumda SmartArt Düğümü Ekle**

Aşağıdaki örnek kodda, SmartArt şeklinin ilgili düğümlerine ait alt düğümlerin belirli bir konuma nasıl ekleneceğini açıkladık.

1. Presentation sınıfının bir örneğini oluşturun.
2. İlk slaytın referansını indeksini kullanarak elde edin.
3. Erişilen slayta bir [**StackedList**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) türünde [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt) şekli ekleyin.
4. Eklenen SmartArt şeklindeki ilk düğüme erişin.
5. Şimdi, seçilen [**Düğüm**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtNode) için konum 2'de bir [**Alt Düğüm**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) ekleyin ve metnini ayarlayın.
6. Sunumu kaydedin.

```java
import com.aspose.slides.*;

// Sunum örneği oluşturma
Presentation pres = new Presentation();
try {
    // Sunum slaytına erişim
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape ekle
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // İndeks 0'da SmartArt düğümüne erişim
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

## **SmartArt Düğümüne Erişim**

Aşağıdaki örnek kod, SmartArt şekli içindeki düğümlere erişmenize yardımcı olacaktır. Lütfen, SmartArt'ın LayoutType'ının şekil eklendiğinde seçildiğini; daha sonra **setLayout** ile değiştirilmesinin tüm diyagramı yeniden oluşturduğunu, bu yüzden ayarladığınız düğüm konum ve boyutlarının yeniden hesaplandığını unutmayın.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
2. İlk slaytın referansını indeksini kullanarak elde edin.
3. İlk slayttaki tüm şekiller arasında dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.
5. SmartArt Şekli içindeki tüm [**Düğümler**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt#getAllNodes--) arasında dolaşın.
6. SmartArt Düğümünün konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```java
import com.aspose.slides.*;

// Sunum sınıfını örnekle
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayttaki tüm şekiller arasında dolaş
    for (IShape shape : slide.getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt içindeki tüm düğümler arasında dolaş
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // İndeks i'deki SmartArt düğümüne erişim
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

## **SmartArt Alt Düğümüne Erişim**

Aşağıdaki örnek kod, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere erişmenize yardımcı olacaktır.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve SmartArt Şekli içeren sunumu yükleyin.
2. İlk slaytın referansını indeksini kullanarak elde edin.
3. İlk slayttaki tüm şekiller arasında dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.
5. SmartArt Şekli içindeki tüm [**Düğümler**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArt#getAllNodes--) arasında dolaşın.
6. Seçilen her SmartArt şekli [**Düğüm**] için, o düğüm içindeki tüm [**Alt Düğümler**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) arasında dolaşın.
7. [**Alt Düğüm**] konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```java
import com.aspose.slides.*;

// Sunum sınıfını örnekle
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // İlk slaytı al
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayttaki tüm şekiller arasında dolaş
    for (IShape shape : slide.getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt içindeki tüm düğümler arasında dolaş
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // İndeks i'deki SmartArt düğümüne erişim
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // İndeks i'deki SmartArt düğümündeki alt düğümler arasında dolaş
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // SmartArt düğümündeki alt düğüme erişim
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

## **Belirli Bir Konumdaki SmartArt Alt Düğümüne Erişim**

Bu örnekte, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere belirli bir konumda nasıl erişileceğini öğreneceğiz.

1. Presentation sınıfının bir örneğini oluşturun.
2. İlk slaytın referansını indeksini kullanarak elde edin.
3. Bir [**StackedList**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) türünde SmartArt şekli ekleyin.
4. Eklenen SmartArt şekline erişin.
5. Erişilen SmartArt şeklinin 0 indeksindeki düğüme erişin.
6. Şimdi, **get_Item()** metodunu kullanarak erişilen SmartArt düğümünde konum 1'deki [**Alt Düğüm**]e erişin.
7. [**Alt Düğüm**] konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```java
import com.aspose.slides.*;

// Sunumu örnekle
Presentation pres = new Presentation();
try {
    // İlk slayta erişim
    ISlide slide = pres.getSlides().get_Item(0);
    
    // İlk slayta SmartArt şekli ekleme
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // İndeks 0'da SmartArt düğümüne erişim
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Üst düğümde konum 1'deki alt düğüme erişim
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // SmartArt alt düğüm parametrelerini yazdırma
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt Düğümünü Kaldır**

Bu örnekte, SmartArt şekli içindeki düğümlerin nasıl kaldırılacağını öğreneceğiz.

1. SmartArt Şekli içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve yükleyin.
2. İlk slaytın referansını indeksini kullanarak elde edin.
3. İlk slayttaki tüm şekiller arasında dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.
5. [SmartArt]ın 0'dan fazla düğümü olup olmadığını kontrol edin.
6. Silinecek SmartArt düğümünü seçin.
7. Şimdi, seçilen düğümü [**RemoveNode**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) metodunu kullanarak kaldırın.
8. Sunumu kaydedin.

```java
import com.aspose.slides.*;

// İstenen sunumu yükle
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // İlk slayttaki tüm şekiller arasında dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // İndeks 0'da SmartArt düğümüne erişim
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

## **Belirli Bir Konumdaki SmartArt Düğümünü Kaldır**

Bu örnekte, SmartArt şekli içindeki düğümlerin belirli bir konumda nasıl kaldırılacağını öğreneceğiz.

1. SmartArt Şekli içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve yükleyin.
2. İlk slaytın referansını indeksini kullanarak elde edin.
3. İlk slayttaki tüm şekiller arasında dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.
5. 0 indeksindeki SmartArt şekil düğümünü seçin.
6. Şimdi, seçilen SmartArt düğümünün 2'den fazla alt düğümü olup olmadığını kontrol edin.
7. **Position 1** konumundaki düğümü [**RemoveNode**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) metodunu kullanarak kaldırın.
8. Sunumu kaydedin.

```java
import com.aspose.slides.*;

// İstenen sunumu yükle
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // İlk slayttaki tüm şekiller arasında dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof SmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // İndeks 0'da SmartArt düğümüne erişim
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

## **SmartArt Nesnesinde Bir Alt Düğüm İçin Özel Konum Ayarla**

Şimdi Aspose.Slides for Android via Java, [SmartArtShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtShape) için [X](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#setX-float-) ve [Y](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#setY-float-) özelliklerini ayarlamayı destekliyor. Aşağıdaki kod parçacığı, özel SmartArtShape konumu, boyutu ve dönüşünün nasıl ayarlanacağını gösterir; ayrıca yeni düğüm eklemenin tüm düğümlerin konum ve boyutlarının yeniden hesaplanmasına neden olduğunu unutmayın. Özel konum ayarları ile kullanıcı, düğümleri gereksinimlerine göre ayarlayabilir.

```java
import com.aspose.slides.*;

// Sunum sınıfını örnekle
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

## **Asistan Düğümünü Kontrol Et**

{{% alert color="info" %}} 
Bu makalede, Aspose.Slides for Android via Java kullanarak sunum slaytlarına programlı olarak eklenen SmartArt şekillerinin özelliklerini daha ayrıntılı inceleyeceğiz.
{{% /alert %}} 

Bu makalenin farklı bölümlerinde inceleme için aşağıdaki kaynak SmartArt şeklinin kullanılacaktır.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Şekil: Slayttaki Kaynak SmartArt Şekli**|

Aşağıdaki örnek kodda, SmartArt düğüm koleksiyonundaki **Asistan Düğümleri** nasıl tanımlanacağını ve değiştirileceğini inceleyeceğiz.

1. SmartArt Şekli içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun ve yükleyin.
2. İlk slaytın referansını indeksini kullanarak elde edin.
3. İlk slayttaki tüm şekiller arasında dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) tipine dönüştürün.
5. SmartArt şekli içindeki tüm düğümler arasında dolaşın ve bunların [**Asistan Düğümleri**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtNode#isAssistant--) olup olmadığını kontrol edin.
6. Asistan Düğümünün durumunu normal düğüm olarak değiştirin.
7. Sunumu kaydedin.

```java
import com.aspose.slides.*;

// Sunum örneği oluşturma
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // İlk slayttaki tüm şekiller arasında dolaş
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (shape instanceof ISmartArt) 
        {
            // Şekli SmartArt tipine dönüştür
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt şeklinin tüm düğümleri arasında dolaş
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Düğümün Asistan düğümü olup olmadığını kontrol et
                if (node.isAssistant()) 
                {
                    // Asistan düğümünü false olarak ayarla ve normal düğüm yap
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
|**Şekil: Slayt içindeki SmartArt şekline eklenen Asistan Düğümleri Değiştirildi**|

## **Bir Düğümün Doldurma Biçimini Ayarla**

Aspose.Slides for Android via Java, özel SmartArt şekilleri eklemeyi ve doldurma biçimlerini ayarlamayı mümkün kılar. Bu makale, SmartArt şekilleri oluşturmayı ve erişmeyi, ayrıca doldurma biçimlerini Aspose.Slides for Android via Java kullanarak nasıl ayarlayacağınızı açıklar.

Lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İndeksini kullanarak bir slaydın referansını elde edin.
3. [**LayoutType**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) ayarlayarak bir [SmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArt) şekli ekleyin.
4. SmartArt şekil düğümleri için [**FillFormat**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape#getFillFormat--) ayarlayın.
5. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunumu örnekle
Presentation pres = new Presentation();
try {
    // Slayta erişim
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt şekli ve düğümler ekleme
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Düğüm doldurma rengini ayarlama
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

## **SmartArt Düğümünün Küçük Resmini Oluştur**

Geliştiriciler, aşağıdaki adımları izleyerek bir SmartArt düğümünün küçük resmini oluşturabilirler:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. [SmartArt Ekle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
3. Bir düğümün referansını indeksini kullanarak elde edin.
4. Küçük resim görüntüsünü alın.
5. Küçük resim görüntüsünü istenilen herhangi bir görüntü formatında kaydedin.

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

### SmartArt animasyonu destekleniyor mu?

Evet. SmartArt normal bir şekil olarak ele alındığından, [standart animasyonlar](/slides/tr/androidjava/shape-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulayabilir ve zamanlamayı ayarlayabilirsiniz. Gerektiğinde SmartArt düğümleri içindeki şekilleri de canlandırabilirsiniz.

### Bir SmartArt'ın iç kimliği bilinmiyorsa, belirli bir slaytta nasıl güvenilir şekilde bulunabilir?

[Alternative text](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getAlternativeText--) atayarak ve bu metni arayarak. SmartArt üzerine belirgin bir AltText ayarlamak, iç kimliklere dayanmak zorunda kalmadan programlı olarak bulmanızı sağlar.

### Sunumu PDF'ye dönüştürürken SmartArt görünümü korunacak mı?

Evet. Aspose.Slides, [PDF dışa aktarımı](/slides/tr/androidjava/convert-powerpoint-to-pdf/) sırasında SmartArt'ı yüksek görsel doğrulukla işler ve yerleşim, renkler ve efektleri korur.

### Tüm SmartArt'ın (ön izlemeler veya raporlar için) bir görüntüsünü çıkarabilir miyim?

Evet. Bir SmartArt şekli, [raster formatlarına](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) ya da [SVG](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) formatına render edilebilir, bu da küçük resimler, raporlar veya web kullanımı için uygundur.