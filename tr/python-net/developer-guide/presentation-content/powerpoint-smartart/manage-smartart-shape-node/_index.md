---
title: Python Kullanarak Sunumlarda SmartArt Şekil Düğümlerini Yönetme
linktitle: SmartArt Şekil Düğümü
type: docs
weight: 30
url: /tr/python-net/manage-smartart-shape-node/
keywords:
- SmartArt düğümü
- alt düğüm
- düğüm ekle
- düğüm konumu
- düğüme erişim
- düğüm kaldırma
- özel konum
- asistan düğüm
- dolgu biçimi
- düğüm renderlama
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PPT, PPTX ve ODP dosyalarındaki SmartArt şekil düğümlerini yönetin. Sunumlarınızı sadeleştirmek için açık kod örnekleri ve ipuçları edinin."
---
## **Genel Bakış**

PowerPoint sunumlarındaki SmartArt grafikler, metin içeren ve diyagramın yapısını tanımlayan düğümler aracılığıyla düzenlenir. Aspose.Slides, bu SmartArt düğümleriyle programlı olarak çalışmanıza olanak tanır: yeni düğümler ve alt düğümler ekleyin, alt düğümleri belirli bir konuma ekleyin, mevcut düğümlere erişin ve metinlerini, seviyelerini ve konumlarını okuyun.

Bu makale, SmartArt şekil düğümlerinin nasıl yönetileceğini açıklar. Düğümlerin nasıl kaldırılacağını, alt düğümlerle indeks veya konumla nasıl çalışılacağını, asistan düğümünün normal düğüme nasıl dönüştürüleceğini, SmartArt düğüm şekillerinin konum, boyut ve döndürülmesinin nasıl ayarlanacağını, düğüm dolgu biçimlerinin nasıl ayarlanacağını ve bir SmartArt alt düğüm için küçük resim görüntüsü nasıl oluşturulacağını gösterir.

## **SmartArt Düğümü Ekle**
Aspose.Slides for Python via .NET, SmartArt şekillerini yönetmek için en basit API'yi sağlamıştır. Aşağıdaki örnek kod, SmartArt şekli içinde düğüm ve alt düğüm eklemenize yardımcı olacaktır.

- SmartArt Şekli içeren sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- İndeksini kullanarak ilk slaytın referansını alın.
- İlk slayttaki tüm şekiller arasında dolaşın.
- Şeklin SmartArt türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt'a tür dönüştürün.
- SmartArt şekli NodeCollection'ına yeni bir düğüm ekleyin ve metni TextFrame içinde ayarlayın.
- Şimdi, yeni eklenen SmartArt düğümüne bir Alt Düğüm ekleyin ve metni TextFrame içinde ayarlayın.
- Sunumu kaydedin.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# İstenen sunumu yükle
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # İlk slayttaki her şekli dolaş
    for shape in pres.slides[0].shapes:

        # Şeklin SmartArt türünde olup olmadığını kontrol et
        if type(shape) is art.SmartArt:
            # Yeni bir SmartArt Düğümü ekleniyor
            node1 = shape.all_nodes.add_node()
            # Metin ekleniyor
            node1.text_frame.text = "Test"

            # Üst düğümde yeni alt düğüm ekleniyor. Koleksiyonun sonuna eklenecek
            new_node = node1.child_nodes.add_node()

            # Metin ekleniyor
            new_node.text_frame.text = "New Node Added"

    # Sunum kaydediliyor
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Belirli Konumda SmartArt Düğümü Ekle**
Aşağıdaki örnek kodda, SmartArt şeklinin ilgili düğümlerine ait alt düğümlerin belirli bir konuma nasıl ekleneceğini açıkladık.

- `Presentation` sınıfının bir örneğini oluşturun.
- İndeksini kullanarak ilk slaytın referansını alın.
- Erişilen slayta StackedList türünde bir SmartArt şekli ekleyin.
- Eklenen SmartArt şeklinin ilk düğümüne erişin.
- Şimdi, seçilen düğüm için konum 2'de bir Alt Düğüm ekleyin ve metnini ayarlayın.
- Sunumu kaydedin.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Bir sunum örneği oluşturma
with slides.Presentation() as pres:
    # Sunum slaytına erişme
    slide = pres.slides[0]

    # Smart Art IShape ekleme
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # İndeks 0'da SmartArt düğümüne erişme
    node = smart.all_nodes[0]

    # Üst düğümde konum 2'de yeni alt düğüm ekleme
    chNode = node.child_nodes.add_node_by_position(2)

    # Metin ekle
    chNode.text_frame.text = "Sample text Added"

    # Sunumu kaydet
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt Düğümüne Erişme**
Aşağıdaki örnek kod, SmartArt şekli içindeki düğümlere erişmenize yardımcı olacaktır. Lütfen, SmartArt'ın LayoutType'ını değiştirmenin mümkün olmadığını, bunun yalnızca SmartArt şekli eklendiğinde ayarlandığını ve salt okunur olduğunu unutmayın.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekli ile sunumu yükleyin.
- İndeksini kullanarak ilk slaytın referansını alın.
- İlk slayttaki tüm şekiller arasında dolaşın.
- Şeklin SmartArt türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt'a tür dönüştürün.
- SmartArt Şekli içindeki tüm Düğümler arasında dolaşın.
- SmartArt Düğümünün konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# İstenen sunumu yükle
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # İlk slayttaki her şekli dolaş
    for shape in pres.slides[0].shapes:
        # Şeklin SmartArt türünde olup olmadığını kontrol et
        if type(shape) is art.SmartArt:
            # SmartArt içindeki tüm düğümleri dolaş
            for i in range(len(shape.all_nodes)):
                # i indeksindeki SmartArt düğümüne erişme
                node = shape.all_nodes[i]

                # SmartArt düğüm parametrelerini yazdırma
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **SmartArt Alt Düğümüne Erişme**
Aşağıdaki örnek kod, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere erişmenize yardımcı olacaktır.

- `PresentationEx` sınıfının bir örneğini oluşturun ve SmartArt Şekli ile sunumu yükleyin.
- İndeksini kullanarak ilk slaytın referansını alın.
- İlk slayttaki tüm şekiller arasında dolaşın.
- Şeklin SmartArt türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArtEx'e tür dönüştürün.
- SmartArt Şekli içindeki tüm Düğümler arasında dolaşın.
- Seçilen her SmartArt şekli Düğümü için, o düğüm içindeki tüm Alt Düğümler arasında dolaşın.
- Alt Düğümün konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# İstenen sunumu yükle
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # İlk slayttaki her şekli dolaş
    for shape in pres.slides[0].shapes:
        # Şeklin SmartArt türünde olup olmadığını kontrol et
        if type(shape) is art.SmartArt:
            # SmartArt içindeki tüm düğümleri dolaş
            for node0 in shape.all_nodes:
                # Alt düğümler arasında dolaş
                for j in range(len(node0.child_nodes)):
                    # SmartArt düğümündeki alt düğüme erişme
                    node = node0.child_nodes[j]

                    # SmartArt alt düğüm parametrelerini yazdırma
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```

## **Belirli Konumdaki SmartArt Alt Düğümüne Erişme**
Bu örnekte, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere belirli bir konumda nasıl erişileceğini öğreneceğiz.

- `Presentation` sınıfının bir örneğini oluşturun.
- İndeksini kullanarak ilk slaytın referansını alın.
- StackedList türünde bir SmartArt şekli ekleyin.
- Eklenen SmartArt şekline erişin.
- Erişilen SmartArt şekli için indeks 0'daki düğüme erişin.
- Şimdi, GetNodeByPosition() yöntemiyle erişilen SmartArt düğümünün konum 1'deki Alt Düğümüne erişin.
- Alt Düğümün konumu, seviyesi ve Metni gibi bilgileri erişin ve görüntüleyin.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Sunumu örnekle
with slides.Presentation() as pres:
    # İlk slayta erişme
    slide = pres.slides[0]
    # İlk slayta SmartArt şekli ekleme
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # İndeks 0'da SmartArt düğümüne erişme
    node = smart.all_nodes[0]
    # Üst düğümde konum 1'deki alt düğüme erişme
    position = 1
    chNode = node.child_nodes[position] 
    # SmartArt alt düğüm parametrelerini yazdırma
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```

## **SmartArt Düğümünü Kaldırma**
Bu örnekte, SmartArt şekli içindeki düğümlerin nasıl kaldırılacağını öğreneceğiz.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekli ile sunumu yükleyin.
- İndeksini kullanarak ilk slaytın referansını alın.
- İlk slayttaki tüm şekiller arasında dolaşın.
- Şeklin SmartArt türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt'a tür dönüştürün.
- SmartArt'ın 0'dan fazla düğümü olup olmadığını kontrol edin.
- Silinecek SmartArt düğümünü seçin.
- Şimdi, RemoveNode() yöntemiyle seçilen düğümü kaldırın* Sunumu kaydedin.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# İstenen sunumu yükle
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # İlk slayttaki her şekli dolaş
    for shape in pres.slides[0].shapes:
        # Şeklin SmartArt türünde olup olmadığını kontrol et
        if type(shape) is art.SmartArt:
            # Şekli SmartArtEx'e tür dönüştür
            if len(shape.all_nodes) > 0:
                # İndeks 0'da SmartArt düğümüne erişme
                node = shape.all_nodes[0]

                # Seçilen düğümü kaldırma
                shape.all_nodes.remove_node(node)

    # Sunumu kaydet
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Belirli Konumdaki SmartArt Düğümünü Kaldırma**
Bu örnekte, SmartArt şekli içindeki düğümlerin belirli bir konumda nasıl kaldırılacağını öğreneceğiz.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekli ile sunumu yükleyin.
- İndeksini kullanarak ilk slaytın referansını alın.
- İlk slayttaki tüm şekiller arasında dolaşın.
- Şeklin SmartArt türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArt'a tür dönüştürün.
- İndeks 0'da bulunan SmartArt şekil düğümünü seçin.
- Şimdi, seçilen SmartArt düğümünün 2'den fazla alt düğümü olup olmadığını kontrol edin.
- Şimdi, RemoveNodeByPosition() yöntemiyle Konum 1'deki düğümü kaldırın.
- Sunumu kaydedin.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# İstenen sunumu yükle
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # İlk slayttaki her şekli dolaş
    for shape in pres.slides[0].shapes:
        # Şeklin SmartArt türünde olup olmadığını kontrol et
        if type(shape) is art.SmartArt:
            # Şekli SmartArt'a tür dönüştür
            if len(shape.all_nodes) > 0:
                # İndeks 0'da SmartArt düğümüne erişme
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Konum 1'deki alt düğümü kaldırma
                    node.child_nodes.remove_node(1)

    # Sunumu kaydet
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt'ta Alt Düğüm İçin Özel Konum Ayarlama**
Artık Aspose.Slides for Python via .NET, SmartArtShape X ve Y özelliklerini ayarlamayı desteklemektedir. Aşağıdaki kod parçacığı, özel SmartArtShape konumu, boyutu ve döndürülmesini nasıl ayarlayacağınızı gösterir; ayrıca yeni düğüm eklemenin tüm düğümlerin konum ve boyutlarının yeniden hesaplanmasına neden olduğunu lütfen unutmayın.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# İstenen sunumu yükle
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# SmartArt şekli yeni konuma taşınıyor
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# SmartArt şeklinin genişliğini değiştir
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# SmartArt şeklinin yüksekliğini değiştir
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# SmartArt şeklinin dönüşünü değiştir
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **Asistan Düğümünü Kontrol Et**
Aşağıdaki örnek kodda, SmartArt düğüm koleksiyonundaki Asistan Düğümlerini nasıl tanımlayacağımızı ve değiştireceğimizi inceleyeceğiz.

- `PresentationEx` sınıfının bir örneğini oluşturun ve SmartArt Şekli ile sunumu yükleyin.
- İndeksini kullanarak ikinci slaytın referansını alın.
- İlk slayttaki tüm şekiller arasında dolaşın.
- Şeklin SmartArt türünde olup olmadığını kontrol edin ve SmartArt ise seçilen şekli SmartArtEx'e tür dönüştürün.
- SmartArt şekli içindeki tüm düğümlerde dolaşın ve bunların Asistan Düğüm olup olmadığını kontrol edin.
- Asistan Düğümün durumunu normal düğüme değiştirin.
- Sunumu kaydedin.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Sunum örneği oluşturma
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # İlk slayttaki her şekli dolaş
    for shape in pres.slides[0].shapes:
        # Şeklin SmartArt türünde olup olmadığını kontrol et
        if type(shape) is art.SmartArt:
            # SmartArt şeklinin tüm düğümleri arasında dolaş
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Düğümün Asistan düğümü olup olmadığını kontrol et
                if node.is_assistant:
                    # Asistan düğümünü false yap ve normal düğüm yap
                    node.is_assistant = False
    # Sunumu kaydet
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Düğümün Dolgu Biçimini Ayarla**
Aspose.Slides for Python via .NET, özel SmartArt şekilleri eklemeyi ve dolgu biçimlerini ayarlamayı mümkün kılar. Bu makale, SmartArt şekilleri oluşturmayı ve erişmeyi ve dolgu biçimlerini Aspose.Slides for Python via .NET kullanarak nasıl ayarlayacağınızı açıklar.

- `Presentation` sınıfının bir örneğini oluşturun.
- İndeksini kullanarak bir slaytın referansını alın.
- LayoutType'ını ayarlayarak bir SmartArt şekli ekleyin.
- SmartArt şekli düğümlerinin FillFormat'ını ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Slayta erişme
    slide = presentation.slides[0]

    # SmartArt şekli ve düğümleri ekleme
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Düğüm dolgu rengini ayarlama
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Sunumu kaydetme
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt Alt Düğümünün Küçük Resmini Oluştur**
Geliştiriciler, aşağıdaki adımları izleyerek bir SmartArt'ın Alt Düğümünün küçük resmini oluşturabilirler:

1. `Presentation` sınıfının bir örneğini oluşturun; bu sınıf PPTX dosyasını temsil eder.
1. SmartArt ekleyin.
1. Bir düğümün referansını indeksini kullanarak alın.
1. Küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir resim formatında kaydedin.

Aşağıdaki örnek, SmartArt alt düğümünün bir küçük resmini oluşturmaktadır

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# PPTX dosyasını temsil eden Presentation sınıfını örnekle 
with slides.Presentation() as presentation: 
    # SmartArt ekle 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Bir düğümün referansını indeksini kullanarak elde et  
    node = smart.nodes[1]

    # Küçük resmi al
    with node.shapes[0].get_image() as bmp:
        # küçük resmi kaydet
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**SmartArt animasyonu destekleniyor mu?**

Evet. SmartArt normal bir şekil olarak ele alınır, bu yüzden [standart animasyonları uygulayabilirsiniz](/slides/tr/python-net/shape-animation/) (giriş, çıkış, vurgu, hareket yolları) ve zamanlamayı ayarlayabilirsiniz. Gerektiğinde SmartArt düğümleri içindeki şekilleri de canlandırabilirsiniz.

**Belirli bir SmartArt'ı, dahili kimliği bilinmiyorsa slayt üzerinde güvenilir bir şekilde nasıl bulabilirim?**

SmartArt'a [alternatif metin](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/alternative_text/) atayarak ve bu metni arayarak bulun. SmartArt üzerinde ayırt edici bir AltText ayarlamak, dahili tanımlayıcılara güvenmeden programlı olarak bulmanızı sağlar.

**Sunumu PDF'ye dönüştürürken SmartArt görünümü korunacak mı?**

Evet. Aspose.Slides, [PDF dışa aktarımı](/slides/tr/python-net/convert-powerpoint-to-pdf/) sırasında SmartArt'ı yüksek görsel sadakatle render eder ve düzeni, renkleri ve efektleri korur.

**Tüm SmartArt'ın (önizlemeler veya raporlar için) bir görüntüsünü çıkarabilir miyim?**

Evet. SmartArt şekli, [raster formatlarına](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/get_image/) veya ölçeklenebilir vektör çıktısı için [SVG](https://reference.aspose.com/slides/tr/python-net/aspose.slides.smartart/smartart/write_as_svg/) render edilebilir; bu da küçük resimler, raporlar veya web kullanımı için uygundur.