---
title: JavaScript Kullanarak Sunumlarda SmartArt Şekil Düğümlerini Yönetme
linktitle: SmartArt Şekil Düğümü
type: docs
weight: 30
url: /tr/nodejs-java/manage-smartart-shape-node/
keywords:
- SmartArt düğümü
- alt düğüm
- düğüm ekle
- düğüm konumu
- düğüm erişimi
- düğüm kaldır
- özel konum
- asistan düğüm
- dolgu biçimi
- düğüm işleme
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PPT ve PPTX dosyalarındaki SmartArt şekil düğümlerini yönetin. Sunumlarınızı daha verimli hale getirmek için net JavaScript kod örnekleri ve ipuçları edinin."
---
## **Genel Bakış**

PowerPoint sunumlarındaki SmartArt grafikler, metin içeren ve diyagramın yapısını tanımlayan düğümler aracılığıyla düzenlenir. Aspose.Slides, bu SmartArt düğümleriyle programatik olarak çalışmanıza olanak tanır: yeni düğümler ve alt düğümler ekleyebilir, alt düğümleri belirli bir konuma ekleyebilir, mevcut düğümlere erişebilir ve bunların metin, seviye ve konumunu okuyabilirsiniz.

Bu makale, SmartArt şekil düğümlerinin nasıl yönetileceğini açıklar. Düğümlerin nasıl kaldırılacağını, alt düğümlerle indeks veya konuma göre nasıl çalışılacağını, asistan düğümünün normal düğüme nasıl dönüştürüleceğini, SmartArt düğüm şekillerinin konum, boyut ve döndürülmesini nasıl ayarlayacağınızı, düğüm dolgu biçimlerini nasıl belirleyeceğinizi ve bir SmartArt alt düğümü için küçük resim oluşturmayı gösterir.

## **PowerPoint Sunumunda JavaScript kullanarak SmartArt Düğümü Ekleme**
Aspose.Slides for Node.js via Java, SmartArt şekillerini yönetmek için en basit API'yi sunar. Aşağıdaki örnek kod, SmartArt şekli içinde düğüm ve alt düğüm eklemeye yardımcı olacaktır.

1. SmartArt Şekli ile sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İndeksini kullanarak ilk slaytın referansını alın.
3. İlk slayttaki tüm şekillerde dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) tipine dönüştürün.
5. [Add a new Node](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) **NodeCollection** içinde yeni bir düğüm ekleyin ve metni TextFrame içinde ayarlayın.
6. Şimdi, yeni eklenen SmartArt düğümüne bir [Add](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) **Child Node**([SmartArtNode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--)) ekleyin ve metni TextFrame içinde ayarlayın.
7. Sunumu kaydedin.

```javascript
// İstenen sunumu yükle
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // İlk slayttaki her şekli dolaş
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Şekli SmartArt tipine dönüştür
            var smart = shape;
            // Yeni bir SmartArt düğümü ekleme
            var TemNode = smart.getAllNodes().addNode();
            // Metin ekleme
            TemNode.getTextFrame().setText("Test");
            // Üst düğüme yeni bir alt düğüm ekleme. Koleksiyonun sonuna eklenecek
            var newNode = TemNode.getChildNodes().addNode();
            // Metin ekleme
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Sunumu kaydet
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Belirli Konumda SmartArt Düğümü Ekleme**
Aşağıdaki örnek kodda, SmartArt şeklinin ilgili düğümlerine ait alt düğümlerin belirli bir konuma nasıl ekleneceği açıklanmıştır.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İndeksini kullanarak ilk slaytın referansını alın.
3. Erişilen slayta bir [**StackedList**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) türünde [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) şekli ekleyin.
4. Eklenen SmartArt şeklinin ilk düğümüne erişin.
5. Seçilen **Node**([SmartArtNode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtNode)) için konum 2'de bir **Child Node**([SmartArtNode#getChildNodes--]) ekleyin ve metnini ayarlayın.
6. Sunumu kaydedin.

```javascript
// Bir sunum örneği oluşturma
var pres = new aspose.slides.Presentation();
try {
    // Sunum slaytına erişim
    var slide = pres.getSlides().get_Item(0);
    // Smart Art IShape ekle
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // 0. indeksteki SmartArt düğümüne erişim
    var node = smart.getAllNodes().get_Item(0);
    // Üst düğümde konum 2'de yeni alt düğüm ekleme
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Metin ekle
    chNode.getTextFrame().setText("Sample Text Added");
    // Sunumu kaydet
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **JavaScript kullanarak PowerPoint Sunumunda SmartArt Düğümüne Erişme**
Aşağıdaki örnek kod, SmartArt şekli içindeki düğümlere nasıl erişileceğini gösterir. SmartArt'ın LayoutType'ının yalnızca okunabilir olduğunu ve yalnızca SmartArt şekli eklenirken ayarlandığını unutmayın.

1. SmartArt Şekli ile sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İndeksini kullanarak ilk slaytın referansını alın.
3. İlk slayttaki tüm şekillerde dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) tipine dönüştürün.
5. SmartArt Şekli içindeki tüm [**Nodes**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt#getAllNodes--) arasında dolaşın.
6. SmartArt Düğümünün konum, seviye ve metin gibi bilgilerini alın ve görüntüleyin.

```javascript
// Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // İlk slaytı al
    var slide = pres.getSlides().get_Item(0);
    // İlk slayttaki her şekli dolaş
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Şekli SmartArt tipine dönüştür
            var smart = shape;
            // SmartArt içindeki tüm düğümleri dolaş
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // i indeksindeki SmartArt düğümüne erişim
                var node = smart.getAllNodes().get_Item(j);
                // SmartArt düğüm parametrelerini yazdırma
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt Alt Düğümüne Erişme**
Aşağıdaki örnek kod, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere nasıl erişileceğini gösterir.

1. SmartArt Şekli ile sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İndeksini kullanarak ilk slaytın referansını alın.
3. İlk slayttaki tüm şekillerde dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) tipine dönüştürün.
5. SmartArt Şekli içindeki tüm [**Nodes**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt#getAllNodes--) arasında dolaşın.
6. Her seçilen SmartArt şekli **Node**([SmartArtNode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtNode)) için belirli bir düğümdeki tüm [**Child Nodes**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) arasında dolaşın.
7. **Child Node**([SmartArtNode#getChildNodes--]) konumu, seviyesi ve metni gibi bilgileri alın ve görüntüleyin.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // İlk slaytı al
    var slide = pres.getSlides().get_Item(0);
    // İlk slayttaki her şekli dolaş
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Şekli SmartArt tipine dönüştür
            var smart = shape;
            // SmartArt içindeki tüm düğümleri dolaş
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // i indeksindeki SmartArt düğümüne erişim
                var node0 = smart.getAllNodes().get_Item(i);
                // i indeksindeki SmartArt düğümündeki alt düğümler arasında dolaş
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // SmartArt düğümündeki alt düğüme erişim
                    var node = node0.getChildNodes().get_Item(j);
                    // SmartArt alt düğüm parametrelerini yazdırma
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Belirli Konumda SmartArt Alt Düğümüne Erişme**
Bu örnekte, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere belirli bir konumda nasıl erişileceği öğrenilecektir.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İndeksini kullanarak ilk slaytın referansını alın.
3. Bir [**StackedList**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) türü SmartArt şekli ekleyin.
4. Eklenen SmartArt şekline erişin.
5. Erişilen SmartArt şeklinin indeks 0'ındaki düğüme erişin.
6. **get_Item()** yöntemiyle erişilen SmartArt düğümünde konum 1'deki [**Child Node**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) alın.
7. **Child Node**([SmartArtNode#getChildNodes--]) konumu, seviyesi ve metni gibi bilgileri alın ve görüntüleyin.

```javascript
// Sunumu örnekle
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişim
    var slide = pres.getSlides().get_Item(0);
    // İlk slayta SmartArt şekli ekleme
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // 0. indeksteki SmartArt düğümüne erişim
    var node = smart.getAllNodes().get_Item(0);
    // Üst düğümde konum 1'deki alt düğüme erişim
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // SmartArt alt düğüm parametrelerini yazdırma
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **JavaScript kullanarak PowerPoint Sunumunda SmartArt Düğümünü Kaldırma**
Bu örnekte, SmartArt şekli içindeki düğümlerin nasıl kaldırılacağı öğrenilecektir.

1. SmartArt Şekli ile sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İndeksini kullanarak ilk slaytın referansını alın.
3. İlk slayttaki tüm şekillerde dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) tipine dönüştürün.
5. [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) içinde 0'dan fazla düğüm olup olmadığını kontrol edin.
6. Silinecek SmartArt düğümünü seçin.
7. Seçilen düğümü [**RemoveNode**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-) yöntemiyle kaldırın.
8. Sunumu kaydedin.

```javascript
// İstenen sunumu yükle
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // İlk slayttaki her şekli dolaş
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Şekli SmartArt tipine dönüştür
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // 0. indeksteki SmartArt düğümüne erişim
                var node = smart.getAllNodes().get_Item(0);
                // Seçilen düğümü kaldırma
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Sunumu kaydet
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Belirli Konumda SmartArt Düğümünü Kaldırma**
Bu örnekte, SmartArt şekli içindeki düğümlerin belirli bir konumda nasıl kaldırılacağı öğrenilecektir.

1. SmartArt Şekli ile sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İndeksini kullanarak ilk slaytın referansını alın.
3. İlk slayttaki tüm şekillerde dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) tipine dönüştürün.
5. İndeks 0'da bulunan SmartArt şekil düğümünü seçin.
6. Seçilen SmartArt düğümünün 2'den fazla alt düğümü olup olmadığını kontrol edin.
7. **Position 1**'deki düğümü [**RemoveNode**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-) yöntemiyle kaldırın.
8. Sunumu kaydedin.

```javascript
// İstenen sunumu yükle
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // İlk slayttaki her şekli dolaş
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Şekli SmartArt tipine dönüştür
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // 0. indeksteki SmartArt düğümüne erişim
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // 1. konumdaki alt düğümü kaldırma
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Sunumu kaydet
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt içinde Alt Düğüm İçin Özel Konum Ayarlama**
Şimdi Aspose.Slides for Node.js via Java, [SmartArtShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtShape) için [X](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#setX-float-) ve [Y](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#setY-float-) özelliklerini ayarlamayı destekliyor. Aşağıdaki kod parçacığı, özel SmartArtShape konumu, boyutu ve döndürülmesini nasıl ayarlayacağınızı gösterir; ayrıca yeni düğüm eklemenin tüm düğümlerin konum ve boyutlarının yeniden hesaplanmasına neden olduğunu unutmayın. Özel konum ayarlarıyla kullanıcı gereksinimlerine göre düğümler ayarlanabilir.

```javascript
// Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // SmartArt şekli yeni konuma taşı
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // SmartArt şeklinin genişliğini değiştir
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // SmartArt şeklinin yüksekliğini değiştir
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // SmartArt şeklinin döndürülmesini değiştir
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Asistan Düğümünü Kontrol Etme**
{{% alert color="primary" %}} 

Bu makalede, Aspose.Slides for Node.js via Java kullanarak sunum slaytlarına programlı olarak eklenen SmartArt şekillerinin özelliklerini daha ayrıntılı inceleyeceğiz.

{{% /alert %}} 

Araştırmamız için aşağıdaki kaynak SmartArt şekli kullanılacaktır.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Şekil: Slaytta Kaynak SmartArt şekli**|

Aşağıdaki örnek kodda, SmartArt düğüm koleksiyonundaki **Assistant Nodes** (Asistan Düğümler) nasıl tanımlanır ve değiştirilir incelenecektir.

1. SmartArt Şekli ile sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İndeksini kullanarak ikinci slaytın referansını alın.
3. İlk slayttaki tüm şekillerde dolaşın.
4. Şeklin [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) türünde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) tipine dönüştürün.
5. SmartArt şekli içindeki tüm düğümlerde dolaşın ve [**Assistant Nodes**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtNode#isAssistant--) olup olmadıklarını kontrol edin.
6. Asistan Düğümünün durumunu normal düğüm olarak değiştirin.
7. Sunumu kaydedin.

```javascript
// Bir sunum örneği oluşturma
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // İlk slayttaki her şekli dolaş
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Şeklin SmartArt türünde olup olmadığını kontrol et
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Şekli SmartArt tipine dönüştür
            var smart = shape;
            // SmartArt şeklinin tüm düğümleri arasında dolaş
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Düğümün Asistan düğümü olup olmadığını kontrol et
                if (node.isAssistant()) {
                    // Asistan düğümünü false olarak ayarla ve normal düğüm yap
                    node.isAssistant();
                }
            }
        }
    }
    // Sunumu kaydet
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Şekil: Slayt içindeki SmartArt şekline eklenen Asistan Düğümleri**|

## **Düğümün Dolgu Biçimini Ayarlama**
Aspose.Slides for Node.js via Java, özel SmartArt şekilleri eklemeyi ve dolgu biçimlerini ayarlamayı mümkün kılar. Bu makale, SmartArt şekillerinin nasıl oluşturulup erişileceğini ve dolgu biçimlerinin nasıl ayarlanacağını açıklamaktadır.

Lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İndeksini kullanarak bir slaytın referansını alın.
3. [**LayoutType**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) ayarlayarak bir [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArt) şekli ekleyin.
4. SmartArt şekli düğümleri için [**FillFormat**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getFillFormat--) ayarlayın.
5. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```javascript
// Sunumu örnekle
var pres = new aspose.slides.Presentation();
try {
    // Slayta erişim
    var slide = pres.getSlides().get_Item(0);
    // SmartArt şekli ve düğümler ekleme
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Düğüm dolgu rengini ayarlama
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Sunumu kaydet
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt Alt Düğümünün Küçük Resmini Oluşturma**
Geliştiriciler aşağıdaki adımları izleyerek bir SmartArt alt düğümünün küçük resmini oluşturabilir:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) ekleyin.
3. İndeksini kullanarak bir düğümün referansını alın.
4. Küçük resim görüntüsünü alın.
5. Küçük resim görüntüsünü istenilen herhangi bir görüntü formatında kaydedin.

```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation();
try {
    // SmartArt ekle
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Bir düğümün referansını indeksini kullanarak al
    var node = smart.getNodes().get_Item(1);
    // Küçük resmi al
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Küçük resmi kaydet
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**SmartArt animasyonu destekleniyor mu?**

Evet. SmartArt normal bir şekil gibi ele alındığı için [standart animasyonlar](/slides/tr/nodejs-java/shape-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulanabilir ve zamanlamalar ayarlanabilir. Gerektiğinde SmartArt düğümleri içindeki şekiller de animasyonlandırılabilir.

**Bir slaytta, iç kimliği bilinmeyen belirli bir SmartArt'ı güvenilir şekilde nasıl bulabilirim?**

[Alternatif metin](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getalternativetext/) (AltText) atayarak ve buna göre arama yaparak. SmartArt üzerinde ayırt edici bir AltText belirlemek, iç kimliklere dayanmak zorunda kalmadan bulmayı sağlar.

**Sunumu PDF'ye dönüştürürken SmartArt görünümü korunur mu?**

Evet. Aspose.Slides, [PDF dışa aktarımı](/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) sırasında SmartArt'ı yüksek görsel doğrulukla işler ve düzen, renk ve efektleri korur.

**Tüm SmartArt'ın (ön izlemeler veya raporlar için) bir görüntüsünü çıkarabilir miyim?**

Evet. SmartArt şekli, [raster formatlarda](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getImage) veya [SVG](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/writeassvg/) olarak işlenebilir; bu sayede küçük resimler, raporlar veya web kullanımı için uygun vektörel veya raster çıktılar elde edilebilir.