---
title: C++ Kullanarak Sunumlarda SmartArt Şekil Düğümlerini Yönetme
linktitle: SmartArt Şekil Düğümü
type: docs
weight: 30
url: /tr/cpp/manage-smartart-shape-node/
keywords:
- SmartArt düğümü
- alt düğüm
- düğüm ekle
- düğüm konumu
- düğüme erişim
- düğüm kaldır
- özel konum
- asistan düğümü
- dolgu biçimi
- düğüm işleme
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PPT ve PPTX dosyalarındaki SmartArt şekil düğümlerini yönetin. Sunumlarınızı kolaylaştırmak için net kod örnekleri ve ipuçları alın."
---
## **Genel Bakış**

PowerPoint sunumlarındaki SmartArt grafikleri, metin içeren ve diyagramın yapısını tanımlayan düğümler aracılığıyla düzenlenir. Aspose.Slides, bu SmartArt düğümleriyle programlı olarak çalışmanıza olanak tanır: yeni düğümler ve alt düğümler ekleyin, alt düğümleri belirli bir konuma ekleyin, mevcut düğümlere erişin ve metinlerini, seviyelerini ve konumlarını okuyun.

Bu makale, SmartArt şekil düğümlerinin nasıl yönetileceğini açıklar. Düğümlerin nasıl kaldırılacağını, alt düğümlerle indeks veya konuma göre nasıl çalışılacağını, asistan bir düğümün normal düğüme nasıl dönüştürüleceğini, SmartArt düğüm şekillerinin konum, boyut ve dönüş ayarlarını nasıl yapacağınızı, düğüm dolgu formatlarını nasıl ayarlayacağınızı ve bir SmartArt alt düğüm için küçük bir resim nasıl oluşturulacağını gösterir.

## **SmartArt Düğümü Ekle**

Aspose.Slides for C++, SmartArt şekillerini en kolay şekilde yönetmek için en basit API'yi sağlamaktadır. Aşağıdaki örnek kod, SmartArt şekli içinde düğüm ve alt düğüm eklemenize yardımcı olacaktır.

- SmartArt Şekli içeren sunumu yükleyerek [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- İlk slaytın referansını indeksini kullanarak elde edin.
- İlk slayt içindeki her şekli gezin.
- Şeklin SmartArt tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArt tipine dönüştürün.
- SmartArt şeklinin NodeCollection'ına yeni bir Node ekleyin ve metni TextFrame içinde ayarlayın.
- Şimdi, yeni eklenen SmartArt Node'una bir Child Node ekleyin ve metni TextFrame içinde ayarlayın.
- Sunumu kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Belirli Bir Konumda SmartArt Düğümü Ekle**

Aşağıdaki örnek kodda, SmartArt şeklinin ilgili düğümlerine ait alt düğümlerin belirli bir konuma nasıl ekleneceğini açıkladık.

- `Presentation` sınıfının bir örneğini oluşturun.
- İlk slaytın referansını indeksini kullanarak elde edin.
- Erişilen slayta StackedList tipinde bir SmartArt şekli ekleyin.
- Eklenen SmartArt şeklinin ilk düğümüne erişin.
- Şimdi, seçilen Node'un 2. konumundaki Child Node'u ekleyin ve metnini ayarlayın.
- Sunumu kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **SmartArt Düğümüne Erişim**

Aşağıdaki örnek kod, SmartArt şekli içindeki düğümlere erişmenize yardımcı olacaktır. Lütfen SmartArt'ın LayoutType'ını değiştiremeyeceğinizi unutmayın; bu değer yalnızca SmartArt şekli eklendiğinde ayarlanır ve yalnızca okunabilir.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekliyle sunumu yükleyin.
- İlk slaytın referansını indeksini kullanarak elde edin.
- İlk slayt içindeki her şekli gezin.
- Şeklin SmartArt tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArt tipine dönüştürün.
- SmartArt Şekli içindeki tüm Node'ları gezin.
- SmartArt Node'un konumu, seviyesi ve metni gibi bilgileri erişin ve görüntüleyin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **SmartArt Alt Düğümüne Erişim**

Aşağıdaki örnek kod, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere erişmenize yardımcı olacaktır.

- PresentationEx sınıfının bir örneğini oluşturun ve SmartArt Şekliyle sunumu yükleyin.
- İlk slaytın referansını indeksini kullanarak elde edin.
- İlk slayt içindeki her şekli gezin.
- Şeklin SmartArt tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArtEx tipine dönüştürün.
- SmartArt Şekli içindeki tüm Node'ları gezin.
- Seçilen her SmartArt şekli Node'u için, ilgili node içindeki tüm Child Node'ları gezin.
- Child Node'un konumu, seviyesi ve metni gibi bilgileri erişin ve görüntüleyin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Belirli Bir Konumda SmartArt Alt Düğümüne Erişim**

Bu örnekte, SmartArt şeklinin ilgili düğümlerine ait alt düğümlere belirli bir konumda nasıl erişileceğini öğreneceğiz.

- `Presentation` sınıfının bir örneğini oluşturun.
- İlk slaytın referansını indeksini kullanarak elde edin.
- StackedList tipinde bir SmartArt şekli ekleyin.
- Eklenen SmartArt şekline erişin.
- Erişilen SmartArt şeklinin 0 indeksindeki node'a erişin.
- Şimdi, GetNodeByPosition() yöntemiyle erişilen SmartArt node'un 1. konumundaki Child Node'a erişin.
- Child Node'un konumu, seviyesi ve metni gibi bilgileri erişin ve görüntüleyin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **SmartArt Düğümünü Kaldır**

Bu örnekte, SmartArt şekli içindeki düğümlerin nasıl kaldırılacağını öğreneceğiz.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekliyle sunumu yükleyin.
- İlk slaytın referansını indeksini kullanarak elde edin.
- İlk slayt içindeki her şekli gezin.
- Şeklin SmartArt tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArt tipine dönüştürün.
- SmartArt'ın 0'dan fazla node'a sahip olup olmadığını kontrol edin.
- Silinecek SmartArt node'unu seçin.
- Şimdi, RemoveNode() yöntemiyle seçilen node'u kaldırın* Sunumu kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Belirli Bir Konumda SmartArt Düğümünü Kaldır**

Bu örnekte, SmartArt şekli içinde belirli bir konumdaki düğümlerin nasıl kaldırılacağını öğreneceğiz.

- `Presentation` sınıfının bir örneğini oluşturun ve SmartArt Şekliyle sunumu yükleyin.
- İlk slaytın referansını indeksini kullanarak elde edin.
- İlk slayt içindeki her şekli gezin.
- Şeklin SmartArt tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArt tipine dönüştürün.
- 0 indeksteki SmartArt şekil node'unu seçin.
- Şimdi, seçilen SmartArt node'unun 2'den fazla child node'a sahip olup olmadığını kontrol edin.
- Şimdi, RemoveNodeByPosition() yöntemiyle 1. konumdaki node'u kaldırın.
- Sunumu kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **SmartArt Alt Düğümü İçin Özel Konum Ayarla**

Artık Aspose.Slides, SmartArtShape X ve Y özelliklerini ayarlamayı desteklemektedir. Aşağıdaki kod parçacığı, özel SmartArtShape konumu, boyutu ve dönüşünü nasıl ayarlayacağınızı gösterir; ayrıca yeni düğüm eklemenin tüm düğümlerin konum ve boyutlarının yeniden hesaplanmasına neden olduğunu unutmayın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Asistan Düğümünü Kontrol Et**

Aşağıdaki örnek kodda, SmartArt node koleksiyonundaki Assistant Node'ları nasıl tanımlayacağımızı ve bunları nasıl değiştireceğimizi inceleyeceğiz.

- PresentationEx sınıfının bir örneğini oluşturun ve SmartArt Şekliyle sunumu yükleyin.
- İkinci slaytın referansını indeksini kullanarak elde edin.
- İlk slayt içindeki her şekli gezin.
- Şeklin SmartArt tipinde olup olmadığını kontrol edin ve eğer SmartArt ise seçilen şekli SmartArtEx tipine dönüştürün.
- SmartArt şekli içindeki tüm node'ları gezin ve bunların Assistant Node olup olmadığını kontrol edin.
- Assistant Node'un durumunu normal node'a değiştirin.
- Sunumu kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Node'un Dolgu Formatını Ayarla**

Aspose.Slides for C++, özel SmartArt şekilleri eklemeyi ve dolgu formatlarını ayarlamayı mümkün kılar. Bu makale, SmartArt şekilleri oluşturup erişmeyi ve Aspose.Slides for C++ kullanarak dolgu formatlarını ayarlamayı açıklar.

- `Presentation` sınıfının bir örneğini oluşturun.
- İndeksini kullanarak bir slaytın referansını elde edin.
- LayoutType'ını ayarlayarak bir SmartArt şekli ekleyin.
- SmartArt şekil node'ları için FillFormat'u ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **SmartArt Alt Düğümünün Küçük Resmini Oluştur**

Geliştiriciler, aşağıdaki adımları izleyerek bir SmartArt'ın Child node'unun küçük resmini (thumbnail) oluşturabilirler:

1. `Presentation` sınıfını, PPTX dosyasını temsil edecek şekilde örnekleyin.
2. SmartArt ekleyin.
3. Indexini kullanarak bir node'un referansını elde edin.
4. Küçük resmi alın.
5. Küçük resmi istediğiniz herhangi bir görüntü formatında kaydedin.

Aşağıdaki örnek, SmartArt alt düğümünün bir küçük resmini oluşturur

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**SmartArt animasyonu destekleniyor mu?**

Evet. SmartArt, normal bir şekil olarak ele alındığından, [standart animasyonlar](/slides/tr/cpp/shape-animation/) (giriş, çıkış, vurgu, hareket yolları) uygulayabilir ve zamanlamayı ayarlayabilirsiniz. Gerektiğinde SmartArt node'ları içindeki şekilleri de animasyonlayabilirsiniz.

**Bir slayttaki belirli bir SmartArt'ı, iç kimliği bilinmiyorsa nasıl güvenilir bir şekilde bulabilirim?**

SmartArt'a [alternatif metin](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/set_alternativetext/) atayarak ve bu metni arayarak. SmartArt üzerinde ayırt edici bir AltText ayarlamak, iç kimliklere bağlı kalmadan programlı olarak bulmanızı sağlar.

**Sunumu PDF'ye dönüştürürken SmartArt görünümü korunacak mı?**

Evet. Aspose.Slides, [PDF dışa aktarımı](/slides/tr/cpp/convert-powerpoint-to-pdf/) sırasında SmartArt'ı yüksek görsel doğrulukla render eder ve düzeni, renkleri ve efektleri korur.

**Tüm SmartArt'ın bir görüntüsünü (ön izlemeler veya raporlar için) çıkarabilir miyim?**

Evet. SmartArt şekli, [raster formatlarına](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getimage/) ya da [SVG](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/writeassvg/) render edilebilir, bu da küçük resimler, raporlar veya web kullanımı için uygun, ölçeklenebilir vektör çıktısı sağlar.