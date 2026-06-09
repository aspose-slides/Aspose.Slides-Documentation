---
title: "C++'ta Sunum Slaytlarına Erişim"
linktitle: "Slayta Erişim"
type: docs
weight: 20
url: /tr/cpp/access-slide-in-presentation/
keywords:
- slayta erişim
- slayt indeksi
- slayt kimliği
- slayt konumu
- konumu değiştir
- slayt özellikleri
- slayt numarası
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlarındaki slaytlara nasıl erişileceğini ve yönetileceğini öğrenin. Kod örnekleriyle verimliliği artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir sunumdaki slaytlara nasıl erişileceğini ve yönetileceğini açıklıyor. Slayt koleksiyonundan sıfır tabanlı indeksle slaytların nasıl alınacağını ve `GetSlideById` yöntemiyle bir slaydın benzersiz kimliğiyle nasıl erişileceğini gösterir.

Ayrıca `set_SlideNumber` yöntemiyle bir slaydın konumunu nasıl değiştireceğinizi ve `set_FirstSlideNumber` yöntemiyle bir sunum için başlangıç slayt numarasını nasıl tanımlayacağınızı öğreneceksiniz. Örnekler, bir sunumu yüklemeyi, slayt referanslarını almayı, slayt sırasını veya numaralandırmasını güncellemeyi ve değiştirilmiş sunumu kaydetmeyi göstermektedir.

## **İndekse Göre Slayta Erişim**

Bir sunumdaki tüm slaytlar, slayt konumu temel alındığında 0'dan başlayarak sayısal olarak düzenlenir. İlk slayt 0. indeks üzerinden erişilebilir; ikinci slayt 1. indeks üzerinden erişilir; vb.

Sunum dosyasını temsil eden Presentation sınıfı, tüm slaytları bir [ISlideCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecollection/) koleksiyonu ( [ISlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) nesnelerinin koleksiyonu) olarak sunar. Bu C++ kodu, bir slayta indeksine göre nasıl erişileceğini gösterir: 

```c++
	// Belgeler dizinine giden yol.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Presentation sınıfını örnekler.
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Bir slaydın referansını indeks üzerinden al.
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Kimliğe Göre Slayta Erişim**

Bir sunumdaki her slayt, kendisine özgü bir kimliğe sahiptir. Bu kimliği hedeflemek için [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı tarafından sunulan [GetSlideById()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/getslidebyid/) yöntemini kullanabilirsiniz. Bu C++ kodu, geçerli bir slayt kimliği sağlamanın ve bu slayta [GetSlideById()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/getslidebyid/) yöntemiyle nasıl erişileceğini gösterir:

```c++
	// Belgeler dizinine giden yol.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Presentation sınıfını örnekler.
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Bir slayd kimliği alır
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Slayta kimliğiyle erişir
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Slayt Konumunu Değiştirme**

Aspose.Slides, bir slaydın konumunu değiştirmenize olanak tanır. Örneğin, ilk slaydın ikinci slayt haline gelmesini belirtebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Pozisyonunu değiştirmek istediğiniz slaydın referansını indeksine göre alın.
1. Slaydın yeni konumunu [set_SlideNumber()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/set_slidenumber/) özelliğiyle ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Bu C++ kodu, konumu 1 olan slaydın konumu 2'ye taşındığı bir işlemi göstermektedir:

```c++
	// Belgeler dizinine giden yol.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Presentation sınıfını örnekler.
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Konumu değiştirilecek slaytı alır
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Slayt için yeni konumu ayarlar
	slide->set_SlideNumber(2);

	// Değiştirilmiş sunumu kaydeder
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

İlk slayt ikinci oldu; ikinci slayt birinci oldu. Bir slaydın konumunu değiştirdiğinizde, diğer slaytlar otomatik olarak ayarlanır.

## **Slayt Numrasını Ayarlama**

[set_FirstSlideNumber()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/set_firstslidenumber/) özelliğini ( [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfı tarafından sunulan) kullanarak bir sunumdaki ilk slayd için yeni bir numara belirleyebilirsiniz. Bu işlem, diğer slayt numaralarının yeniden hesaplanmasına neden olur.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayt numarasını alın.
1. Slayt numarasını ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Bu C++ kodu, ilk slayt numarasının 10 olarak ayarlandığı bir işlemi göstermektedir: 

```c++
	// Belgeler dizinine giden yol.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Presentation sınıfını örnekler
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Slayt numarasını alır
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Slayt numarasını ayarlar
	pres->set_FirstSlideNumber(2);
	
	// Değiştirilmiş sunumu kaydeder
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

İlk slaytı atlamak isterseniz, numaralandırmayı ikinci slayttan başlatabilir (ve ilk slayt için numaralandırmayı gizleyebilirsiniz) şu şekilde:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **SSS**

**Kullanıcının gördüğü slayt numarası, koleksiyonun sıfır tabanlı indeksine eşleşir mi?**

Bir slaytta gösterilen numara, isteğe bağlı bir değerden (örneğin 10) başlayabilir ve indeksle eşleşmek zorunda değildir; ilişki, sunumun [first slide number](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/set_firstslidenumber/) ayarı tarafından kontrol edilir.

**Gizli slaytlar indekslemeyi etkiler mi?**

Evet. Gizli bir slayt koleksiyonda kalır ve indekslemeye dahil edilir; “gizli” ifadesi, slaydın görüntülenmesiyle ilgilidir, koleksiyondaki konumuyla değil.

**Diğer slaytlar eklendiğinde veya kaldırıldığında bir slaydın indeksi değişir mi?**

Evet. İndeksler, slaytların mevcut sırasını her zaman yansıtır ve ekleme, silme ve taşıma işlemleri sırasında yeniden hesaplanır.