---
title: C++ ile Sunumlardan Slaytları Kaldırma
linktitle: Slaytı Kaldır
type: docs
weight: 30
url: /tr/cpp/remove-slide-from-presentation/
keywords:
- slaytı kaldır
- slaytı sil
- kullanılmayan slaytı kaldır
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarından slaytları zahmetsizce kaldırın. Açık kod örnekleri alın ve iş akışınızı hızlandırın."
---
## **Giriş**

Bir slayt (veya içeriği) gereksiz hale gelirse, silebilirsiniz. Aspose.Slides, bir sunumdaki tüm slaytlar için bir depo olan [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) öğesini kapsülleyen [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfını sağlar. Bilinen bir [ISlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) nesnesi için işaretçiler (referans veya indeks) kullanarak, kaldırmak istediğiniz slaytı belirtebilirsiniz. 

## **Referansla Slayt Kaldırma**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Kaldırmak istediğiniz slaytı ID veya indeks aracılığıyla bir referans olarak alın.  
1. Referans verilen slaytı sunumdan kaldırın.  
1. Değiştirilmiş sunumu kaydedin. 

Bu C++ kodu, bir slaytı referans yoluyla nasıl kaldıracağınızı gösterir: 

```c++
	// Belgeler dizinine olan yol
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Bir sunum dosyasını temsil eden Presentation nesnesini oluşturur
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Slaytlar koleksiyonundaki indeks aracılığıyla bir slayta erişir
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Bir slaytı referansı aracılığıyla kaldırır
	pres->get_Slides()->Remove(slide);

	// Değiştirilmiş sunumu kaydeder
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **İndeks ile Slayt Kaldırma**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Slaytı indeks konumuna göre sunumdan kaldırın.  
1. Değiştirilmiş sunumu kaydedin. 

Bu C++ kodu, bir slaytı indeks yoluyla nasıl kaldıracağınızı gösterir: 

```c++
	// Belgeler dizinine olan yol
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Bir sunum dosyasını temsil eden Presentation nesnesini oluşturur
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Slayt indeksini kullanarak bir slaytı kaldırır
	pres->get_Slides()->RemoveAt(0);

	// Değiştirilmiş sunumu kaydeder
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Kullanılmayan Yerleşim Slaytlarını Kaldırma**

Aspose.Slides, istenmeyen ve kullanılmayan yerleşim slaytlarını silmenize olanak tanıyan [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) sınıfındaki [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) yöntemini sağlar. Bu C++ kodu, bir PowerPoint sunumundaki bir yerleşim slaytını nasıl kaldıracağınızı gösterir:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Kullanılmayan Ana Slaytları Kaldırma**

Aspose.Slides, istenmeyen ve kullanılmayan ana slaytları silmenize olanak tanıyan [Compress](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/) sınıfındaki [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/tr/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) yöntemini sağlar. Bu C++ kodu, bir PowerPoint sunumundaki bir ana slaytı nasıl kaldıracağınızı gösterir:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **SSS**

**Bir slaytı sildikten sonra slayt indeksleri ne olur?**

Silme işleminden sonra, [collection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidecollection/) yeniden indekslenir: sonraki her slayt bir konum sola kayar, böylece önceki indeks numaraları artık geçerli değildir. Sabit bir referansa ihtiyacınız varsa, indeks yerine her slaytın kalıcı kimliğini (ID) kullanın.

**Bir slaytın ID'si indeksinden farklı mıdır ve komşu slaytlar silindiğinde değişir mi?**

Evet. İndeks, slaytın konumudur ve slaytlar eklendiğinde veya silindiğinde değişir. Slayt ID'si kalıcı bir tanımlayıcıdır ve diğer slaytlar silinse bile değişmez.

**Bir slaytı silmek slayt bölümlerini nasıl etkiler?**

Slayt bir bölüme aittiyse, o bölüm sadece bir slayt az olur. Bölüm yapısı korunur; bir bölüm boşalırsa, ihtiyacınıza göre [bölümleri kaldırabilir veya yeniden düzenleyebilirsiniz](/slides/tr/cpp/slide-section/).

**Silinen bir slayta ekli notlar ve yorumlar ne olur?**

[Notes](/slides/tr/cpp/presentation-notes/) ve [comments](/slides/tr/cpp/presentation-comments/) belirli slayta bağlıdır ve slaytla birlikte kaldırılır. Diğer slaytlardaki içerik etkilenmez.

**Slayt silmek ile kullanılmayan yerleşim/ana slaytları temizlemek arasındaki fark nedir?**

Silme, dektaki belirli normal slaytları kaldırır. Kullanılmayan yerleşim/ana slaytları temizleme, hiçbir nesne tarafından başvurulmayan yerleşim veya ana slaytları kaldırarak dosya boyutunu azaltır ve kalan slayt içeriğini değiştirmez. Bu işlemler birbirini tamamlar: genellikle önce slaytları silin, ardından temizleme yapın.