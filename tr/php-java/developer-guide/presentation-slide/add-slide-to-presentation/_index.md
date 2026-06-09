---
title: PHP'de Sunumlara Slayt Ekleme
linktitle: Slayt Ekle
type: docs
weight: 10
url: /tr/php-java/add-slide-to-presentation/
keywords:
- slayt ekle
- slayt oluştur
- boş slayt
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlarınıza kolayca slayt ekleyin — sorunsuz, etkili slayt ekleme işlemi saniyeler içinde."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarına programlı olarak slayt eklemenizi sağlar. Bir sunum, ana / düzen slaytları ve normal slaytlar içerir; normal slaytlar sıfırdan başlayan bir indekse göre sıralanır. Her slaytın benzersiz bir kimliği vardır ve slaytsız sunum dosyaları desteklenmez.

Bu makale, bir `Presentation` nesnesi oluşturmayı, slayt koleksiyonuna erişmeyi, boş bir slayt eklemeyi, yeni eklenen slaytla çalışmayı ve güncellenmiş sunumu kaydetmeyi açıklar. Ayrıca belirli bir konuma slayt ekleme, düzen kullanma ve yeni oluşturulan bir sunumda mevcut olan boş slaytı anlama gibi ilgili konuları da kapsar.

## **Sunuma Slayt Ekleme**

Sunum dosyalarına slayt ekleme konusuna geçmeden önce, slaytlarla ilgili bazı gerçekleri inceleyelim. Her PowerPoint sunum dosyası **Ana / Düzen** slaytı ve diğer **Normal** slaytları içerir. Bu, bir sunum dosyasının en az bir veya daha fazla slayt içerdiği anlamına gelir. Aspose.Slides for PHP via Java, slaytsız sunum dosyalarını desteklemez. Her slaytın benzersiz bir Id'si vardır ve tüm Normal Slaytlar sıfırdan başlayan bir indeksle sıralanır.

Aspose.Slides for PHP via Java, geliştiricilerin sunumlarına boş slaytlar eklemelerine olanak tanır. Sunuma boş bir slayt eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Sunum nesnesi tarafından açığa çıkarılan [getSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation#getSlides--) (içerik Slide nesneleri koleksiyonu) yöntemini kullanarak [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) nesnesini alın.
- İçerik slaytları koleksiyonunun sonuna boş bir slayt eklemek için [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) nesnesi tarafından açığa çıkarılan [**addEmptySlide**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/#addEmptySlide) yöntemini çağırın.
- Yeni eklenen boş slayt ile bir takım işlemler yapın.
- Son olarak, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) nesnesini kullanarak sunum dosyasını yazın.

```php
  # Sunum dosyasını temsil eden Presentation sınıfını örnekle
  $pres = new Presentation();
  try {
    # SlideCollection sınıfını örnekle
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Slides koleksiyonuna boş bir slayt ekle
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Yeni eklenen slayt üzerinde bir takım işlemler yap
    # PPTX dosyasını diske kaydet
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **SSS**

**Yeni bir slaytı sadece sonuna değil, belirli bir konuma ekleyebilir miyim?**

Evet. Kütüphane slayt koleksiyonlarını ve [insert](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/insertclone/) işlemlerini destekler, bu sayede slaytı yalnızca sonuna değil, istenen indeks konumuna da ekleyebilirsiniz.

**Bir düzen temelinde slayt eklerken tema/stiller korunur mu?**

Evet. Bir düzen, üstünden (master) biçimlendirmeyi devralır ve yeni slayt seçilen düzeni ve ona bağlı master'ı devralır.

**Yeni bir “boş” sunumda slayt eklemeden önce hangi slayt bulunur?**

Yeni oluşturulan bir sunum zaten indeks sıfırda bir boş slayt içerir. Bu, ekleme indekslerini hesaplarken dikkate alınması gereken bir durumdur.

**Master birçok seçenek sunduğunda yeni bir slayt için “doğru” düzeni nasıl seçerim?**

Genellikle, gereken yapıya ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidelayouttype/)) uyan [LayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) seçilir. Böyle bir düzen eksikse, [add it to the master](/slides/tr/php-java/slide-layout/) ile master'a ekleyebilir ve ardından kullanabilirsiniz.