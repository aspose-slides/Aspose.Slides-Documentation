---
title: .NET'te Sunumlara Slayt Ekle
linktitle: Slayt Ekle
type: docs
weight: 10
url: /tr/net/add-slide-to-presentation/
keywords:
- slayt ekle
- slayt oluştur
- boş slayt
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument sunumlarınıza kolayca slayt ekleyin—saniyeler içinde sorunsuz ve verimli slayt ekleme."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarına programlı olarak slayt eklemenizi sağlar. Bir sunum, ana/yerleşim slaytları ve normal slaytlar içerir ve normal slaytlar sıfır‑tabanlı bir indeksle düzenlenir. Her slaytın benzersiz bir kimliği vardır ve slaytsız sunum dosyaları desteklenmez.

Bu makale, bir `Presentation` nesnesi oluşturmayı, slayt koleksiyonuna erişmeyi, boş bir slayt eklemeyi, yeni eklenen slaytla çalışmayı ve güncellenmiş sunumu kaydetmeyi açıklar. Ayrıca belirli bir konuma slayt ekleme, yerleşimler kullanma ve yeni oluşturulan bir sunumda var olan boş slaytı anlama gibi ilgili konuları da kapsar.

## **Bir Sunuma Slayt Ekle**
Slayt ekleme konusuna geçmeden önce slaytlar hakkında bazı gerçekleri inceleyelim. Her PowerPoint sunum dosyası, Ana / Yerleşim slaytı ve diğer Normal slaytları içerir. Bu, bir sunum dosyasının en az bir veya daha fazla slayt içerdiği anlamına gelir. Aspose.Slides for .NET tarafından slaytsız sunum dosyalarının desteklenmediğini bilmek önemlidir. Her slaytın benzersiz bir Id’si vardır ve tüm Normal Slaytlar sıfır‑tabanlı indeksle belirtilen bir sırada düzenlenir. Aspose.Slides for .NET, geliştiricilerin sunumlarına boş slayt eklemelerine olanak tanır. Sunuma boş bir slayt eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Presentation nesnesi tarafından sağlanan Slides (içerik Slayt nesnelerinin koleksiyonu) özelliğine bir referans belirleyerek [ISlideCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecollection) sınıfının bir örneğini oluşturun.
- ISlideCollection nesnesi tarafından sağlanan AddEmptySlide metodunu çağırarak içerik slaytları koleksiyonunun sonuna boş bir slayt ekleyin.
- Yeni eklenen boş slayt ile bazı işlemler yapın.
- Son olarak, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) nesnesini kullanarak sunum dosyasını yazın.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **SSS**

**Yeni bir slaytı, sadece sonuna eklemek yerine belirli bir konuma ekleyebilir miyim?**

Evet. Kütüphane slayt koleksiyonlarını ve insert/clone işlemlerini destekler, bu nedenle slaytı yalnızca sonuna değil, istediğiniz indekse ekleyebilirsiniz.

**Bir slaytı yerleşime dayalı eklerken tema/stiller korunur mu?**

Evet. Bir yerleşim, ana slaytından biçimlendirmeyi devralır ve yeni slayt seçilen yerleşimden ve ona bağlı ana slayttan devralır.

**Slayt eklemeden önce yeni “boş” bir sunumda hangi slayt bulunur?**

Yeni oluşturulan bir sunum zaten sıfır indeksiyle bir boş slayt içerir. Bu, ekleme indekslerini hesaplarken dikkate alınması gereken bir durumdur.

**Ana slaytta birçok seçenek varsa, yeni bir slayt için “doğru” yerleşimi nasıl seçebilirim?**

Genellikle gereken yapıya (Başlık ve İçerik, İki İçerik vb.) uyan LayoutSlide'ı seçersiniz. Böyle bir yerleşim yoksa, onu ana slayta ekleyebilir ve ardından kullanabilirsiniz.