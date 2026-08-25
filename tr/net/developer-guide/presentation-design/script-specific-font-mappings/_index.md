---
title: ".NET'te Script-Özgü Tema Fontlarını Yönetme"
linktitle: "Script-Özgü Tema Fontları"
type: docs
weight: 15
url: /tr/net/script-specific-font-mappings/
keywords:
- script-özgü font
- tema font haritalaması
- çok dilli sunum
- yazı sistemi
- Kiril fontu
- Arapça fontu
- Japonca fontu
- Gürcüce fontu
- Thaana fontu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint temalarında script-özgü font haritalamalarını inceleyin, ekleyin, değiştirin ve kaldırın; .NET için Aspose.Slides ile."
---
## **Genel Bakış**

Bir sunum teması, farklı yazı sistemleri için farklı yazı tipi aileleri seçebilir. Bu, temanın fontlarını kullanan çok dilli metnin, Kiril, Arapça, Japonca, Gürcüce, Thaana ve diğer betikler için uygun fontları kullanırken tek bir koordine font şeması izleyebilmesini sağlar.

Temanın [IFontScheme](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/ifontscheme/) içinde, genellikle başlıklar için kullanılan ana bir font koleksiyonu ve genellikle gövde metni için kullanılan ikincil bir font koleksiyonu bulunur. Latin ve Doğu Asya font özelliklerine ek olarak, her iki koleksiyon da [IFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/ifonts/) arabirimi üzerinden yazı‑sistemi etiketlerinden font aile adlarına haritalamaları sunar.

Bu makale, sunumun ana temasındaki bu haritalamaları nasıl inceleyeceğinizi, değiştireceğinizi ve değişikliklerin kaydedilip yeniden yüklendiğinde de korunduğunu nasıl doğrulayacağınızı gösterir.

## **Script Etiketlerini Anlayın**

Script font yöntemleri, yazı sistemlerini tanımlamak için dört harfli BCP 47 script alt etiketlerini kullanır. Yaygın değerler şunlardır:

| Script tag | Yazı sistemi |
|---|---|
| `Cyrl` | Kiril |
| `Arab` | Arapça |
| `Hans` | Basitleştirilmiş Çince |
| `Jpan` | Japonca |
| `Geor` | Gürcüce |
| `Thaa` | Thaana |

Bu haritalamalar tema font şemasına aittir, tek tek metin bölümlerine değil. Bir sunum, ana ve ikincil koleksiyonlar için farklı haritalamalar tanımlayabilir ve bazı scriptler için haritalamaları atlayabilir.

## **Script Font Eşlemelerini Erişme ve İnceleme**

Sunum‑seviyesindeki temaya erişmek için [Presentation.MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/mastertheme/) kullanın. [FontScheme.Major](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.Minor](https://reference.aspose.com/slides/tr/net/aspose.slides.theme/fontscheme/minor/) özellikleri iki [IFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/ifonts/) koleksiyonunu döndürür.

Bir koleksiyondaki tüm haritalamaları almak için [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/tr/net/aspose.slides/fonts/getscriptfontmap/) çağırın. Tek bir yazı sistemi için bakmak istiyorsanız, script etiketini kullanarak [IFonts.GetScriptFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fonts/getscriptfont/) çağırın. `GetScriptFont`, istenen haritalama tanımlı değilse `null` döndürür.

## **Eşlemeleri Değiştir ve Kalıcılığı Doğrula**

Yeni bir haritalama oluşturmak veya mevcut font ailesini değiştirmek için [IFonts.SetScriptFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fonts/setscriptfont/) kullanın. Bir haritalamayı kaldırmak için [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fonts/removescriptfont/) kullanın.

Aşağıdaki uç‑uç örnek, mevcut tüm ana ve ikincil haritalamaları okur, Japonca ana fontunu bulur, Kiril ana fontunu değiştirir, Thaana ikincil haritalamayı kaldırır, sunumu kaydeder ve iki değişikliğin de korunduğunu doğrulamak için yeniden açar. Kaldırma adımının başlangıç temasından bağımsız olması için, örnek bir Thaana haritalaması yalnızca önceden tanımlı değilse oluşturur.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

Doğrulama, normal bir bakışta olduğu gibi aynı `null` davranışını kullanır: kaldırma kaydedildikten sonra, `GetScriptFont("Thaa")` ikincil koleksiyon için `null` döndürür.

## **Tema Eşlemelerini Diğer Font Ayarlarından Ayırın**

Script‑özgü tema haritalamaları font seçimine katılır, ancak doğrudan metin biçimlendirme, ikame ve geri dönüş gibi farklı sorunları çözer:

| Mekanizma | Amaç | Tema eşlemesinin değiştirilmesinin etkisi |
|---|---|---|
| Script‑özgü tema font eşlemesi | Bir yazı sistemi için ana ya da ikincil tema fontunu seçer. | İlgili tema fontunu hâlâ kullanan metin, yeni eşlenen aileye çözülebilir. |
| Metin bölümüne açıkça atanmış font | İsteği font ailesini tema yerine o bölüme sabitler. | Bölüm, doğrudan biçimlendirmesi tema seçimini geçersiz kıldığından değişmeden kalabilir. |
| Font ikamesi | İstenen font mevcut değilse ya da bir ikame kuralı uygulandığında fontu değiştirir. | Bir font istendikten sonra devreye girer; tema’nın script eşlemesini yeniden tanımlamaz. |
| Font geri dönüşü | Seçilen fontun içermediği glifleri, genellikle belirli Unicode aralıkları için sağlar. | Eksik glif kapsamını doldurur; saklanan tema eşlemesini değiştirmez. |

Son iki mekanizma hakkında daha fazla bilgi için [Font Substitution](/slides/tr/net/font-substitution/) ve [Fallback Fonts](/slides/tr/net/fallback-font/) sayfalarına bakın.

[Presentation.MasterTheme](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/mastertheme/) içindeki bir eşlemeyi değiştirmek, yalnızca etkili biçimlendirmesi hâlâ bu temaya bağlı olan içeriği etkiler. Metin, bir master, layout veya slayt üzerinden bir tema geçersiz kılma alıyor ya da açıkça atanmış bir font kullanıyor olabilir. Görünür sonuç tema eşlemesine uymuyorsa bu seviyeleri inceleyin.

## **Eşlenen Fontları Kullanılabilir Hale Getir ve Sonucu Doğrula**

Bir script haritalaması sadece bir font ailesi adını saklar; ilgili font dosyasını kurmaz veya yüklemez. Tutarlı render ve dışa aktarma için, her eşlenen font ortamda kurulu olmalı ya da Aspose.Slides’a [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/tr/net/aspose.slides/fontsloader/loadexternalfonts/) veya [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/documentlevelfontsources/) gibi özel bir kaynak üzerinden temin edilmelidir. Kullanılabilir yükleme seçenekleri için [Custom Fonts](/slides/tr/net/custom-font/) sayfasına bakın.

Kaydedilen haritalamayı doğrulamak sadece tema tanımının korunduğunu gösterir. Fontun mevcut olduğunu, gerekli tüm glifleri içerdiğini veya istenen düzeni ürettiğini kanıtlamaz. Her gerekli yazı sistemi için temsilci bir metni görüntü ya da PDF olarak render edip çıktıyı inceleyin. Bu, eksik fontları, yetersiz glif kapsamını, geri dönüş davranışını ve sunum dağıtılmadan önceki düzen değişikliklerini yakalar. Render ve dışa aktarma örnekleri için [Convert PowerPoint Presentations](/slides/tr/net/convert-powerpoint/) sayfasına bakın.

## **SSS**

**`GetScriptFont` bir script haritalanmadığında ne döndürür?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fonts/getscriptfont/) istenen script haritalaması o ana ya da ikincil font koleksiyonunda tanımlı değilse `null` döndürür.

**`SetScriptFont` script zaten mevcutken ikinci bir haritalama ekler mi?**

Hayır. [IFonts.SetScriptFont](https://reference.aspose.com/slides/tr/net/aspose.slides/fonts/setscriptfont/) eksik olduğunda haritalamayı oluşturur ve aynı script etiketi zaten varsa eşlenen font ailesini değiştirir.

**Tema haritalaması değiştirildiğinde bazı metinler neden etkilenmedi?**

Metin açıkça atanmış bir font taşıyor, bir geçersiz kılma aracılığıyla farklı bir temadan devralınmış olabilir veya render sırasında ikame ya da geri dönüşten etkileniyor olabilir. Sunum‑seviyesi script haritalaması yalnızca etkili biçimlendirmesi hâlâ o tema font koleksiyonuna referans veren metni kontrol eder.

**Kaydedip yeniden açmak çok dilli çıktıyı doğrulamak için yeterli mi?**

Hayır. Yeniden açmak tema verisinin kalıcılığını doğrular. Ayrıca her gerekli yazı sistemi için temsilci bir metni render edip eşlenen fontların kullanılabilir ve gerekli glifleri içerdiğini onaylamak gerekir.