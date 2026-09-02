---
title: C++'ta Betik-özel Tema Yazı Tiplerini Yönet
linktitle: Betik-özel Tema Yazı Tipleri
type: docs
weight: 15
url: /tr/cpp/script-specific-font-mappings/
keywords:
- betik-özel yazı tipi
- tema yazı tipi eşlemesi
- çok dilli sunum
- yazı sistemi
- Kiril yazı tipi
- Arapça yazı tipi
- Japonca yazı tipi
- Gürcüce yazı tipi
- Thaana yazı tipi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint temalarında betik-özel yazı tipi eşlemelerini inceleyin, ekleyin, değiştirin ve kaldırın."
---
## **Genel Bakış**

Bir sunum teması, farklı yazı sistemleri için farklı yazı tipi aileleri seçebilir. Bu, temanın yazı tiplerini kullanan çok dilli metnin, Kiril, Arapça, Japonca, Gürcüce, Thaana ve diğer betikler için uygun yazı tiplerini kullanırken uyumlu bir yazı tipi şeması izleyebilmesini sağlar.

Temanın [IFontScheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/ifontscheme/) içinde genellikle başlıklar için kullanılan bir ana (major) yazı tipi koleksiyonu ve gövde metin için kullanılan bir yan (minor) koleksiyon bulunur. Latin ve Doğu Asya yazı tipi özelliklerine ek olarak, her iki koleksiyon da [IFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifonts/) arayüzü aracılığıyla yazı sistemi etiketlerinden yazı tipi aile adı eşleştirmelerine erişim sağlar.

Bu makale, sunumun ana temasında bu eşlemeleri nasıl inceleyeceğinizi ve değiştirip bir kaydet‑yeniden‑yükleme döngüsünden sonra değişikliklerin korunduğunu nasıl doğrulayacağınızı gösterir.

## **Betik Etiketlerini Anlamak**

Betik yazı tipi metodları, yazı sistemlerini tanımlamak için dört harflik BCP 47 betik alt etiketlerini kullanır. Yaygın değerler şunlardır:

| Betik etiketi | Yazı sistemi |
|---|---|
| `Cyrl` | Kiril |
| `Arab` | Arapça |
| `Hans` | Basitleştirilmiş Çince |
| `Jpan` | Japonca |
| `Geor` | Gürcüce |
| `Thaa` | Thaana |

Bu eşlemeler tema yazı tipi şemasına aittir, bireysel metin bölümlerine değil. Bir sunum, ana ve yan koleksiyonlar için farklı eşlemeler tanımlayabilir ve bazı betikler için eşleme atlayabilir.

## **Betik Yazı Tipi Eşlemelerini Erişim ve İnceleme**

Sunum‑seviyesindeki temaya erişmek için [Presentation::get_MasterTheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_mastertheme/) kullanın. [FontScheme::get_Major](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/fontscheme/get_major/) ve [FontScheme::get_Minor](https://reference.aspose.com/slides/tr/cpp/aspose.slides.theme/fontscheme/get_minor/) metodları iki [IFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifonts/) koleksiyonunu döndürür.

Bir koleksiyondaki tüm eşlemeleri elde etmek için [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fonts/getscriptfontmap/) çağırın. Tek bir yazı sistemini bulmak için [Fonts::GetScriptFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fonts/getscriptfont/) metoduna betik etiketini verin. `GetScriptFont`, istenen eşleme koleksiyonda tanımlı değilse null bir dize döndürür.

## **Eşlemeleri Değiştir ve Kalıcılığı Doğrula**

Bir eşleme oluşturmak veya mevcut yazı tipi ailesini değiştirmek için [Fonts::SetScriptFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fonts/setscriptfont/) kullanın. Bir eşlemeyi kaldırmak için [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fonts/removescriptfont/) kullanın.

Aşağıdaki uçtan‑uyağa örnek, mevcut tüm ana ve yan eşlemeleri okur, Japonca ana yazı tipini bulur, Kiril ana yazı tipini değiştirir, Thaana yan eşlemeyi kaldırır, sunumu kaydeder ve yeniden açarak her iki değişikliği de doğrular. Kaldırma adımının başlangıç temasından bağımsız olmasını sağlamak için, örnek sadece bir Thaana eşlemesi tanımlı değilse oluşturur.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

Doğrulama, sıradan bir aramadan aynı null‑dize davranışını kullanır: kaldırma kaydedildikten sonra `GetScriptFont(u"Thaa")` yan koleksiyon için null bir dize döndürür.

## **Tema Eşlemelerini Diğer Yazı Tipi Ayarlarından Ayırmak**

Betik‑özgü tema eşlemeleri yazı tipi seçiminde yer alır, ancak doğrudan metin biçimlendirme, ikame ve geri dönüş (fallback) gibi farklı sorunları çözer:

| Mekanizma | Amaç | Tema eşlemesini değiştirdiğinizde etkisi |
|---|---|---|
| Betik‑özgü tema yazı tipi eşlemesi | Bir yazı sistemi için ana veya yan tema yazı tipini seçer. | İlgili tema yazı tipini hâlâ kullanan metin, yeni eşlenen aileye çözülebilir. |
| Metin bölümüne açıkça atanan yazı tipi | O bölümde temaya güvenmek yerine istenen yazı tipi ailesini sabitler. | Doğrudan biçimlendirme temayı geçersiz kıldığından, bölüm değişmeden kalabilir. |
| Yazı tipi ikamesi | İstenen yazı tipi mevcut değilse veya bir ikame kuralı varsa değiştirilir. | Yazı tipi istendiği anda devreye girer; tema betik eşlemesini yeniden tanımlamaz. |
| Yazı tipi geri dönüşü | Seçilen yazı tipinde bulunmayan glifleri, özellikle belirli Unicode aralıkları için temin eder. | Eksik glif kapsamasını doldurur; saklanan tema eşlemesini değiştirmez. |

Son iki mekanizma hakkında daha fazla bilgi için [Font Substitution](/slides/tr/cpp/font-substitution/) ve [Fallback Fonts](/slides/tr/cpp/fallback-font/) bölümlerine bakın.

[Presentation::get_MasterTheme](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_mastertheme/) içindeki bir eşlemeyi değiştirmek, yalnızca etkin biçimlendirmesi hâlâ o temeye bağlı olan içeriği etkiler. Metin, bir master, layout veya slayt üzerinden tema geçersiz kılma alabilir ya da açıkça atanmış bir yazı tipi kullanabilir. Görünür sonuç tema eşlemesine uymuyorsa bu seviyeleri inceleyin.

## **Eşlenmiş Yazı Tiplerini Kullanılabilir Kıl ve Sonucu Doğrula**

Betik eşlemesi sadece bir yazı tipi ailesi adını saklar; ilgili yazı tipi dosyasını kurmaz veya yüklemez. Tutarlı render ve dışa aktarma için, her eşlenmiş yazı tipinin ortamda kurulmuş olması ya da Aspose.Slides’a özel bir kaynak üzerinden sağlanması gerekir; örneğin [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fontsloader/loadexternalfonts/) veya [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) gibi. Kullanılabilir yükleme seçenekleri için [Custom Fonts](/slides/tr/cpp/custom-font/) sayfasına bakın.

Kaydedilen eşlemenin doğrulanması yalnızca tema tanımının korunduğunu gösterir. Yazı tipinin erişilebilir, gerekli tüm glifleri içerdiği veya hedeflenen düzeni ürettiği kanıtlanmaz. Her gerekli yazı sistemi için temsili bir metni görüntü ya da PDF’ye render edip çıktıyı inceleyin. Bu, eksik yazı tipleri, yetersiz glif kapsaması, geri dönüş davranışı ve sunum dağıtılmadan önceki düzen değişikliklerini yakalar. Render ve dışa aktarma örnekleri için [Convert PowerPoint Presentations](/slides/tr/cpp/convert-powerpoint/) bölümüne göz atın.

## **SSS**

**`GetScriptFont` bir betik eşlenmemiş olduğunda ne döndürür?**  
[Fonts::GetScriptFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fonts/getscriptfont/) istenen betik eşlemesi ilgili ana ya da yan koleksiyonda tanımlı değilse null bir dize döndürür.

**`SetScriptFont` betik zaten mevcutken ikinci bir eşleme ekler mi?**  
Hayır. [Fonts::SetScriptFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides/fonts/setscriptfont/) eksik olduğunda eşleme oluşturur, aynı betik etiketi zaten mevcutsa eşlenen yazı tipi ailesini değiştirir.

**Neden bir tema eşlemesini değiştirmek bazı metinlerde etkili olmadı?**  
Metin açıkça atanmış bir yazı tipine sahip olabilir, farklı bir temadan kalıtım alıyor olabilir ya da render sırasında ikame ya da geri dönüşten etkileniyor olabilir. Sunum‑seviyesi betik eşlemesi yalnızca etkin biçimlendirmesi hâlâ o tema yazı tipi koleksiyonuna başvuran metni kontrol eder.

**Kaydedip yeniden açmak çokdilli çıktıyı doğrulamak için yeterli mi?**  
Hayır. Yeniden açma tema verisinin kalıcılığını doğrular. Ayrıca her gerekli yazı sistemi için temsili metni render edip eşlenmiş yazı tiplerinin erişilebilir ve gerekli glifleri içerdiğini onaylamak gerekir.