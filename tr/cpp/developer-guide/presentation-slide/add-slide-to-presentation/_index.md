---
title: C++'ta Sunumlara Slayt Ekleme
linktitle: Slayt Ekle
type: docs
weight: 10
url: /tr/cpp/add-slide-to-presentation/
keywords:
- slayt ekleme
- slayt oluşturma
- boş slayt
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlarınıza slayt eklemenin kolay yolu — sorunsuz, verimli slayt ekleme saniyeler içinde."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarına programlı olarak slayt eklemenizi sağlar. Bir sunum, ana/layout slaytları ve normal slaytlar içerir ve normal slaytlar sıfır‑bazlı bir indeksle düzenlenir. Her slaytın benzersiz bir kimliği vardır ve slaytsız sunum dosyaları desteklenmez.

Bu makale, bir `Presentation` nesnesi oluşturmayı, slayt koleksiyonuna erişmeyi, boş bir slayt eklemeyi, yeni eklenen slayt ile çalışmayı ve güncellenmiş sunumu kaydetmeyi açıklar. Ayrıca, slaytları belirli bir konuma ekleme, düzenleri (layout) kullanma ve yeni oluşturulan bir sunumda bulunan boş slaytı anlama gibi ilgili konuları da kapsar.

## **Sunuma Slayt Ekleme**

Sunum dosyalarına slayt eklemeden önce, slaytlarla ilgili bazı gerçekleri ele alalım. Her PowerPoint sunum dosyası, Ana / Layout slaytı ve diğer Normal slaytları içerir. Bu, bir sunum dosyasının en az bir veya daha fazla slayt içerdiği anlamına gelir. Aspose.Slides for C++ tarafından slaytsız sunum dosyalarının desteklenmediğini bilmek önemlidir. Her slaytın benzersiz bir Id'si vardır ve tüm Normal Slaytlar, sıfır‑bazlı indeksle belirtilen bir sırada düzenlenir. Aspose.Slides for C++ geliştiricilerin sunumlarına boş slaytlar eklemesine olanak tanır. Sunuma boş bir slayt eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
- [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) sınıfını, Presentation nesnesi tarafından sunulan Slides (içerik Slide nesnelerinin koleksiyonu) özelliğine bir referans ayarlayarak örnekleyin.
- ISlideCollection nesnesi tarafından sağlanan AddEmptySlide metodunu çağırarak, içerik slaytları koleksiyonunun sonuna bir boş slayt ekleyin.
- Yeni eklenen boş slayt üzerinde bazı işlemler yapın.
- Son olarak, [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) nesnesini kullanarak sunum dosyasını yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **SSS**

**Belirli bir konuma yeni bir slayt ekleyebilir miyim, sadece sonuna değil?**

Evet. Kütüphane, slayt koleksiyonlarını ve [insert](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidecollection/insertclone/) işlemlerini destekler, böylece sadece sonuna eklemek yerine gerekli indeksde bir slayt ekleyebilirsiniz.

**Bir layout temelinde slayt eklerken tema/stiller korunur mu?**

Evet. Bir layout, master'ından biçimlendirmeyi devralır ve yeni slayt, seçilen layout ve ona bağlı master'dan devralır.

**Slayt eklemeden önce yeni bir "boş" sunumda hangi slayt bulunur?**

Yeni oluşturulan bir sunum zaten sıfır indeksli bir boş slayt içerir. Bu, ekleme indekslerini hesaplarken dikkate alınması gereken bir durumdur.

**Master'da birçok seçenek varsa yeni bir slayt için "doğru" layout nasıl seçilir?**

Genellikle, gereken yapıya uyan [LayoutSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/layoutslide/) seçilir ([Title and Content, Two Content, vb.](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slidelayouttype/)). Böyle bir layout eksikse, [add it to the master](/slides/tr/cpp/slide-layout/) ve ardından kullanabilirsiniz.