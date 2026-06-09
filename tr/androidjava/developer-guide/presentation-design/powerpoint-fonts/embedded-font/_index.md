---
title: Android'de Sunumlara Yazı Tipi Gömme
linktitle: Yazı Tipi Gömme
type: docs
weight: 40
url: /tr/androidjava/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi gömme
- yazı tipi gömme
- gömülü yazı tipini al
- gömülü yazı tipi ekle
- gömülü yazı tipini kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument sunumlarına TrueType yazı tiplerini gömerek, tüm platformlarda doğru render alınmasını sağlar."
---
## **Giriş**

**PowerPoint'ta gömülü yazı tipleri** faydalıdır çünkü sunumunuzun herhangi bir sistem veya cihazda açıldığında doğru görünmesini istersiniz. Çalışmanızda yaratıcı olduğunuz için üçüncü taraf ya da standart dışı bir yazı tipi kullandıysanız, yazı tipinizi gömmek için daha da fazla nedeniniz olur. Aksi takdirde (gömülü yazı tipleri olmadan), slaytlarınızdaki metinler veya sayılar, düzen, stil vb. değişebilir veya karışık dikdörtgenlere dönüşebilir.  

Bu [FontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsManager) sınıfı, [FontData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontdata/) sınıfı, [Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) sınıfı ve bunların arayüzleri, PowerPoint sunumlarında gömülü yazı tipleriyle çalışmanız için gereken çoğu özellik ve yöntemi içerir.

## **Gömülü Yazı Tiplerini Al ve Kaldır**

Aspose.Slides, bir sunumda gömülü olan yazı tiplerini almanıza (veya öğrenmenize) olanak tanıyan [getEmbeddedFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) yöntemini ([FontsManager](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/FontsManager) sınıfı tarafından sunulur) sağlar. Yazı tiplerini kaldırmak için aynı sınıf tarafından sunulan [removeEmbeddedFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) yöntemi kullanılır.

Bu Java kodu, bir sunumdan gömülü yazı tiplerini nasıl alıp kaldıracağınızı gösterir:

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini oluşturur
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Gömülü "FunSized" kullanan bir metin çerçevesi içeren slaytı render eder
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Görseli JPEG formatında diske kaydeder
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Tüm gömülü yazı tiplerini alır
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // "Calibri" yazı tipini bulur
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // "Calibri" yazı tipini kaldırır
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Sunumu render eder; "Calibri" yazı tipi mevcut bir yazı tipiyle değiştirilir
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // Görseli JPEG formatında diske kaydeder
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Gömülü "Calibri" yazı tipi olmadan sunumu diske kaydeder
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gömülü Yazı Tiplerini Ekle**

[EmbedFontCharacters](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/embedfontcharacters/) enum'ını ve [addEmbeddedFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) yönteminin iki aşırı yüklemesini kullanarak, bir sunumda yazı tiplerini gömmek için tercih ettiğiniz (gömme) kuralını seçebilirsiniz. Bu Java kodu, bir sunuma nasıl yazı tipleri gömeceğinizi ve ekleyeceğinizi gösterir:

```java
// Sunumu yükler
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // Sunumu diske kaydeder
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gömülü Yazı Tiplerini Sıkıştır**

Bir sunumda gömülü yazı tiplerini sıkıştırarak dosya boyutunu azaltmanızı sağlamak için Aspose.Slides, [compressEmbeddedFonts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) yöntemini ([Compress](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/compress/) sınıfı tarafından sunulur) sağlar.

Bu Java kodu, gömülü PowerPoint yazı tiplerini nasıl sıkıştıracağınızı gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Bir sunumdaki belirli bir yazı tipinin gömülmüş olmasına rağmen render sırasında hala ikame edileceğini nasıl anlayabilirim?**  
Yazı tipi yöneticisindeki [substitution information](/slides/tr/androidjava/font-substitution/) ve [fallback/substitution rules](/slides/tr/androidjava/fallback-font/) sayfalarına bakın: yazı tipi bulunamazsa veya kısıtlıysa, bir yedek (fallback) kullanılacaktır.

**Arial/Calibri gibi “sistem” yazı tiplerini gömmeye değer mi?**  
Genellikle hayır—bu yazı tipleri neredeyse her zaman mevcuttur. Ancak “ince” ortamlar (Docker, önceden yüklü yazı tipleri olmayan bir Linux sunucusu) içinde tam taşınabilirlik için sistem yazı tiplerini gömmek, beklenmedik ikameler riskini ortadan kaldırabilir.