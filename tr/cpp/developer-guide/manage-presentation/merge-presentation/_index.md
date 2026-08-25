---
title: C++'ta Sunumları Etkin Bir Şekilde Birleştir
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/cpp/merge-presentation/
keywords:
- PowerPoint'i birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- PowerPoint'i birleştir
- sunumları birleştir
- slaytları birleştir
- PPT'yi birleştir
- PPTX'i birleştir
- ODP'yi birleştir
- C++
- Aspose.Slides
description: "C++'ta slaytları kopyalayarak, master ve layout'ları kontrol ederek, slayt içeriğini yeniden boyutlandırarak, bölümleri koruyarak ve korumalı ya da büyük dosyaları yöneterek PowerPoint ve OpenDocument sunumlarını nasıl birleştireceğinizi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for C++ sunumları, bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) dan diğerine slaytları kopyalayarak birleştirir. Ana işlem, kaynak slaydının biçimlendirmesini koruyabilecek veya kopyalanan slaytı hedef sunumdaki bir master ya da layout’a ekleyebilecek olan [ISlideCollection::AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) yöntemidir.

Bu makale en yaygın birleştirme senaryolarını kapsar:

- kaynak biçimlendirmesini koruyarak tüm slaytları birleştir;
- seçili slaytları birleştir;
- hedef sunumdan bir master uygula;
- hedef sunumdan belirli bir layout uygula;
- birleştirmeden önce farklı slayt boyutlarını normalleştir;
- kopyalanan slaytları bir bölüme ekle;
- birden fazla sunumu uçtan uca bir iş akışı içinde birleştir;
- master’lar, kaynaklar, notlar, yorumlar, medya, fontlar, şifreler, büyük dosyalar ve çok iş parçacıklı kullanım konularını ele al.

## **Slayt Kopyalamanın Master ve Layout’lar Üzerindeki Etkisi**

Bir slayt, görünümünün büyük bir kısmını layout ve master’dan devralır. Bu nedenle, seçtiğiniz kopyalama aşırı yüklemesi, birleştirilen slaydın hedef sunuma nasıl entegre edileceğini belirler.

[ISlideCollection::AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) yöntemini şu şekillerde kullanın:

- `AddClone(sourceSlide)` — kaynak slaydının layout ve biçimlendirmesini korur. Gerekirse, kaynak master otomatik olarak hedef sunuma kopyalanır. Aspose.Slides, otomatik kopyalanan master’ları izler; aynı kaynak master’ı kullanan tekrar eden slaytlar bu master’ın tekrarlı kopyalanmasını önler.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — kopyalanan slaytı belirli bir hedef [IMasterSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imasterslide/)’a ekler. Aspose.Slides, bu master altında layout tipine ya da adına göre eşleşen bir layout arar.
- `AddClone(sourceSlide, destinationLayout)` — kopyalanan slaytı doğrudan belirli bir hedef [ILayoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilayoutslide/)’a ekler.

`AddClone` aşırı yüklemesine geçirilen master veya layout, **kaynak** sunumun değil **hedef** sunumun bir parçası olmalıdır.

## **Tüm Sunumları Birleştir ve Kaynak Biçimlendirmesini Koru**

En basit birleştirme, kaynak sunumdaki tüm slaytları hedef sunuma kopyalar. Bu, içe aktarılan slaytların özgün tema, master ve layout ilişkilerini koruması gerektiğinde uygundur.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

Kaynak ve hedef farklı tasarımlar kullandığında sonuç sunum birden fazla master içerebilir. Bu, kaynak biçimlendirmesinin kasıtlı olarak korunması durumunda beklenen bir durumdur.

## **Seçili Slaytları Birleştir**

Tüm slaytları kopyalamanız gerekmez. Aşağıdaki örnek, kaynak sunumdan yalnızca seçili slayt indekslerini içe aktarır.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Kullanıcı girişi ya da dış yapılandırmadan gelen indeksleri kopyalamadan önce doğrulayın.

## **Hedef Master Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların zaten hedef sunuma ait bir master’ı takip etmesi gerektiğinde [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) aşırı yüklemesini kullanın.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides, kaynak layout tipine ya da adına göre belirtilen master altında uygun bir layout seçer. Uygun bir layout yoksa ve `allowCloneMissingLayout` **true** ise, kaynak layout kopyalanarak slayt eklenir. **false** ise bir [PptxEditException](https://reference.aspose.com/slides/tr/cpp/aspose.slides/details_pptxeditexception/) fırlatılır.

Ek bir layout eklemek istemiyorsanız, birleştirmenin başarısız olmasını sağlamak için **false** kullanın.

## **Belirli Bir Hedef Layout Kullanarak Slaytları Birleştir**

İçe aktarılan slaytların kesinlikle belirli bir hedef layout’u kullanması gerektiğinde [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) aşırı yüklemesini kullanın.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Hedef layout’un uygulanması, kalıtılan layout ilişkisinin değiştirilmesi anlamına gelir; kaynak slayt içeriği yeniden tasarlamaz. Kaynak ve hedef layout’ların yer tutucu yapıları farklıysa, kalıtılan biçimlendirme ve yer tutucu davranışının uygun olup olmadığını kontrol edin.

## **Farklı Slayt Boyutlarına Sahip Sunumları Birleştir**

Farklı slayt boyutlarına sahip sunumlar birleştirilebilir, ancak bir slaytı başka bir slayt boyutuna kopyalamak içeriği yeni tuval için otomatik olarak yeniden tasarlamaz. Bu nedenle şekiller kaydırılmış, beklenmedik şekilde ölçeklenmiş ya da görünür slayt alanının dışına çıkmış görünebilir.

Pratik bir yaklaşım, kopyalamadan önce kaynak sunumu yeniden boyutlandırmaktır. [SlideSize::SetSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidesize/setsize/) yöntemi, slayt boyutlarını değiştirirken mevcut içeriği ölçeklendirebilir. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidesizescaletype/) ise içeriği istenen boyuta sığdıracak şekilde ölçeklendirir.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Yeniden boyutlandırma, kaynak sunum nesnesini bellekte değiştirir. Orijinal kaynak sunumun diğer işlemler için değişmeden kalması gerekiyorsa, birleştirme sırasında ayrı bir örnek açın.

## **Slaytları Bir Sunum Bölümüne Birleştir**

Temel slayt kopyalama döngüsü, kaynak sunumun bölüm hiyerarşisini yeniden oluşturmaz. Çıktıda bölümler önemliyse, hedef sunumda bölümler oluşturun veya seçin ve slaytları açıkça [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) ile bu bölümlere kopyalayın.

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

Kopyalanan slaytlar belirtilen hedef bölüme eklenir. Birden fazla kaynak bölümü korumak için [Presentation::get_Sections](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_sections/) ile bölümleri enumerate edin, her kaynak bölümün mevcut slaytlarını [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/isection/getslideslistofsection/) ile alın, bölümleri hedefte yeniden yaratın ve her dönen slaytı karşılık gelen hedef bölümüne kopyalayın. Tam bir bölüm enumerate örneği için [Manage Slide Sections](/slides/tr/cpp/slide-section/) sayfasına bakın; örnek boş bölümler ve yapısal değişiklikleri de içerir.

## **Birden Fazla Sunumu Güvenli Şekilde Birleştir**

Aşağıdaki uçtan uca örnek, ilk sunumu hedef olarak alır, ek kaynakların slayt boyutlarını normalleştirir, her kaynağı yalnızca kopyalanırken açık tutar ve dosyayı son kez kaydeder.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Bu, içe aktarılmış slaytların kaynak biçimlendirmesini korumak için yararlı bir temel sağlar. Çıktının tek bir hedef teması olmalıysa, basit `AddClone(slide)` çağrısını daha önce gösterilen uygun hedef‑master ya da hedef‑layout aşırı yüklemesi ile değiştirin.

## **Pratik Hususlar**

### **Master’lar, Layout’lar ve Biçimlendirme Sadakati**

Varsayılan slayt kopyalama, gerekli bir kaynak master’ı otomatik olarak hedef sunuma getirebilir. Aspose.Slides, aynı master’ın tekrar tekrar kopyalanmasını önlemek için otomatik kopyalanan master’ları izleyen dahili bir kayıt tutar. Manuel olarak kopyalanan master’lar bu kayıt tarafından izlenmez; bu yüzden master’ları önceden kopyalamaktan kaçının, yalnızca master yapısı üzerinde kesin kontrol gerektiğinde yapın.

Aynı ada sahip iki master ya da layout’un görsel olarak eşdeğer olduğunu varsaymayın. Kurumsal bir şablon nihai görünümü kontrol ediyorsa, hedef master ya da layout’u açıkça seçin ve birleştirme sonrası sonucu doğrulayın.

### **Notlar ve Yorumlar**

Sunucu notları ve slayt yorumları slayt içeriğiyle ilişkilidir ve bir slayt kopyalandığında da kopyalanır. Aspose.Slides ayrıca [sunum notları](/slides/tr/cpp/presentation-notes/) ve [sunum yorumları](/slides/tr/cpp/presentation-comments/) için özel API’ler sunar.

Not sayfası biçimlendirmesi önemliyse, birleştirilmiş sunumu kontrol edin; çünkü not master’ları sunum‑seviyesi nesnelerdir ve kaynak dosyalar arasında farklılık gösterebilir. İnceleme iş akışları için, farklı yazarlar ya da şablonlardan gelen dosyaları birleştirdikten sonra yorum yazarlarını ve iş parçacıklı yorumları da doğrulayın.

### **Görüntüler, Ses, Video, OLE Nesneleri ve Dış Bağlantılar**

Slaytlar, sunum‑seviyesi kaynaklar (görüntüler, gömülü ses, gömülü video ve OLE verileri) referans gösterebilir. Sadece görünen şekilleri kopyalamak yerine slaytı tamamen kopyalayın; böylece Aspose.Slides, slaydın kaynaklara olan ilişkilerini korur.

Gömülü ve bağlanmış kaynaklar farklı şekilde ele alınmalıdır. Bağlanmış bir ses, video, OLE nesnesi ya da köprü, dış hedefine bağımlı kalır; slaytı kopyalamak dış bir bağlantıyı gömülü içeriğe dönüştürmez. Bağlantılı kaynak yollarını ve URL’leri, birleştirilmiş sunumun açılacağı ortamda test edin.

Aspose.Slides, otomatik kopyalanan master’ları izler, ancak bu, birbirinden bağımsız kaynak sunumlardan gelen aynı ikili kaynakların her zaman tekilleştirileceği anlamına gelmez. Çıktı dosya boyutu önemliyse, birleştirilmiş paketi inceleyin ve sonucu ölçün; örtük tekilleştirmeye güvenmeyin.

### **Gömülü Fontlar ve Font Kullanılabilirliği**

Fontlar sunum‑seviyesinde yönetilir. Tipografi makineler arasında tutarlı kalmalıysa, sadece slaytları kopyalamanın bütün gerekli fontların hedef ortamda bulunacağını varsaymayın. Gömülü fontları [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsmanager/getembeddedfonts/) ile inceleyebilir ve [Sunumlarda Font Gömme](/slides/tr/cpp/embedded-font/) bölümünde açıklandığı gibi gömülmesini açıkça yönetebilirsiniz.

Ayrıca, kaynak dosyalarda kullanılan fontları gömmeye izin verilip verilmediğini kontrol edin. Font lisansları gömme hakkını sınırlayabilir.

### **Şifre Koruması Altındaki Sunumlar**

Şifre korumalı bir kaynak, slaytları kopyalamadan önce başarıyla açılmalıdır. Şifreyi [LoadOptions::set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) aracılığıyla sağlayın.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Şifreli bir kaynağı açmak, aynı korumanın hedef sunuma otomatik olarak uygulanacağı anlamına gelmez. Gerektiğinde çıktı korumasını ayrı olarak yapılandırın.

### **Büyük Sunumlar ve Bellek Kullanımı**

Yüksek çözünürlüklü görüntüler, ses, video ya da diğer büyük ikili nesneler içeren büyük sunumlar önemli bellek tüketebilir. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) BLOB yönetimi ve geçici dosya kullanımını kontrol eder. Büyük‑dosya stratejileri için [Sunum BLOB’larını Yönet](/slides/tr/cpp/manage-blob/) sayfasına bakın.

Büyük dosyalar için mümkün olduğunca dosya yollarından yükleme tercih edin, her kaynak sunumu birleştirme tamamlandığında derhal serbest bırakın ve iş akışı kontrol noktaları gerektirmiyorsa ara sonuçları tekrar tekrar kaydetmekten kaçının.

### **İş Parçacığı Güvenliği**

Aynı [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini birden fazla iş parçacığından aynı anda yüklemeyin, değiştirmeyin, kaydetmeyin ya da kopyalamayın. Her sunum örneğini tek bir birleştirme işlemiyle sınırlı tutun. Bağımsız işleri paralelleştirirken bağımsız sunum örnekleri kullanın ve [Aspose.Slides çok iş parçacıklı rehberi](/slides/tr/cpp/multithreading/) izleyin.

## **SSS**

**Kaynak her bir sunumun özgün tasarımını nasıl korurum?**

Hedef master ya da layout sağlamadan [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) yöntemini kullanın. Aspose.Slides, içe aktarılmış slayt tarafından ihtiyaç duyulduğunda kaynak master’ı otomatik olarak kopyalayabilir.

**İçe aktarılan slaytların hedef temayı kullanmasını nasıl sağlarım?**

Bir hedef master kabul eden aşırı yüklemeyi kullanın. Master’ı kaynak sunumdan değil, hedef sunumdan seçin. Aspose.Slides, her kaynak slaytı o master altındaki uygun bir layout’a eşlemeye çalışır.

**Ne zaman belirli bir hedef layout kullanmalı, hedef master yerine?**

Her içe aktarılan slaytın aynı bilinen layout’u kullanması gerektiğinde belirli bir layout seçin. Slaytların kaynak layout tipine ya da adına göre master’ın layout’ları arasından seçim yapmasını istiyorsanız master kullanın.

**Farklı slayt boyutlarına sahip sunumlar birleştirilebilir mi?**

Evet, ancak slayt içeriği hedef boyutlara otomatik olarak yeniden tasarlanmamaktadır. Öngörülebilir konumlandırma için önce [SlideSize::SetSize](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidesize/setsize/) ve [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidesizescaletype/) ile kaynak sunumu yeniden boyutlandırın.

**PPT, PPTX ve ODP sunumlarını tek bir dosyada birleştirebilir miyim?**

Evet. Her kaynak sunumu yükleyin, gereken slaytları tek bir hedefe kopyalayın ve hedefi desteklenen bir çıktı formatında kaydedin. Sunum formatları aynı özellik setini tam olarak desteklemediği için çapraz‑format birleştirmelerden sonra karmaşık içeriği doğrulayın. [Desteklenen Dosya Formatları](/slides/tr/cpp/supported-file-formats/) sayfasına bakın.

**Kaynak bölümler otomatik olarak korunur mu?**

Sadece slaytları kopyalayan temel bir döngü bölümleri korumaz. Gerekli bölümleri hedefte yeniden oluşturun ve bölüm yapısı korunmalıysa [AddClone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/addclone/) yöntemiyle bölüm aşırı yüklemesini kullanın.

**Konuşmacı notları ve yorumlar korunur mu?**

Kopyalanan slaytla birlikte kopyalanırlar. Not‑master stilizasyonu, yorum yazarları veya iş parçacıklı inceleme verileri gibi sunum‑seviyesi yapıların önemli olduğu iş akışlarında, birleştirilmiş sonucu doğrulayın.

**Ses, video, OLE nesneleri ve köprüler ne olur?**

Gömülü içerik, kopyalanan slaydın kaynak ilişkileriyle birlikte taşınır. Dış bağlantılar dışarıda kalır; hedef dosyalar ya da URL’ler birleştirmeden sonra hâlâ erişilebilir olmalıdır.

**Her kaynaktan gelen gömülü fontlar birleştirilmiş sunumda garanti olarak bulunur mu?**

Sadece slayt kopyalamaya güvenmeyin. Hedefteki gömülü fontları inceleyin ve tipografi önemliyse font gömme ya da harici font bulunabilirliğini açıkça yönetin.

**Şifre korumalı bir dosyayı nasıl birleştiririm?**

Doğru [LoadOptions::set_Password](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_password/) ile açın, ardından slaytları normal şekilde kopyalayın. Çıktı koruması ayrı olarak yapılandırılır.

**Çok büyük sunumları nasıl yönetirim?**

BLOB yönetimini kullanın, çok büyük dosyalar için dosya‑yolu yüklemeyi tercih edin, kaynak sunumları birleştirme tamamlandığında hemen serbest bırakın ve final sonucu yalnızca gerektiğinde kaydedin.

**Slaytları birden fazla iş parçacığından birleştirebilir miyim?**

Aynı [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini birden fazla iş parçacığından aynı anda kullanmayın. Her birleştirme işlemini kendi sunum örnekleriyle izole edin.