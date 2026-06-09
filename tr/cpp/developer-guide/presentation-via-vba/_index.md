---
title: C++ Kullanarak Sunumlarda VBA Projelerini Yönetme
linktitle: VBA ile Sunum
type: docs
weight: 250
url: /tr/cpp/presentation-via-vba/
keywords:
- makro
- VBA
- VBA makrosu
- makro ekle
- makro kaldır
- makro çıkar
- VBA ekle
- VBA kaldır
- VBA çıkar
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "VBA ile PowerPoint ve OpenDocument sunumlarını oluşturmayı ve yönetmeyi, C++ için Aspose.Slides kullanarak, iş akışınızı kolaylaştıracak şekilde keşfedin."
---
## **Giriş**

Aspose.Slides.Vba ad alanı, makrolar ve VBA kodu ile çalışmak için sınıflar ve arabirimler içerir.

{{% alert title="Note" color="warning" %}} 

Makrolar içeren bir sunumu farklı bir dosya biçimine (PDF, HTML vb.) dönüştürdüğünüzde, Aspose.Slides tüm makroları yok sayar (makrolar ortaya çıkan dosyaya taşınmaz).

Sunuma makrolar eklerseniz veya makrolar içeren bir sunumu yeniden kaydederseniz, Aspose.Slides yalnızca makroların baytlarını yazar.

Aspose.Slides bir sunumdaki makroları **asla** çalıştırmaz.

{{% /alert %}}

## **VBA Makroları Ekle**

Aspose.Slides, VBA projeleri (ve proje referansları) oluşturmanıza ve mevcut modülleri düzenlemenize olanak tanıyan [VbaProject](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.vba.vba_project) sınıfını sağlar. Sunuma gömülü VBA'yı yönetmek için [IVbaProject](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.vba.i_vba_project/) arabirimini kullanabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
2. Yeni bir VBA projesi eklemek için [VbaProject](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) yapıcısını kullanın.
3. VbaProject'e bir modül ekleyin.
4. Modülün kaynak kodunu ayarlayın.
5. <stdole>'a referansları ekleyin.
6. **Microsoft Office**'a referansları ekleyin.
7. Referansları VBA projesiyle ilişkilendirin.
8. Sunumu kaydedin.

Bu C++ kodu, bir sunuma sıfırdan VBA makrosu eklemenizi gösterir: 

```c++
// Belgeler dizininin yolu.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Sunum sınıfının bir örneğini oluşturur
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Yeni bir VBA Projesi oluşturur
presentation->set_VbaProject(MakeObject<VbaProject>());

// VBA projesine boş bir modül ekler
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Modülün kaynak kodunu ayarlar
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// <stdole> için bir referans oluşturur
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Office için bir referans oluşturur
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBA projesine referansları ekler
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Sunumu kaydeder
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 

Makroları PowerPoint, Excel ve Word belgelerinden kaldırmak için kullanılan ücretsiz bir web uygulaması **Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros) incelemek isteyebilirsiniz. 

{{% /alert %}} 

## **VBA Makrolarını Kaldır**

[Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı altındaki [VbaProject](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) özelliğini kullanarak bir VBA makrosunu kaldırabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun ve makro içeren sunumu yükleyin.
2. Macro modülüne erişin ve onu kaldırın.
3. Değiştirilen sunumu kaydedin.

Bu C++ kodu, bir VBA makrosunu nasıl kaldıracağınızı gösterir: 

```c++
// Belgeler dizininin yolu.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Makroyu içeren sunumu yükler
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Vba modülüne erişir ve onu kaldırır 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Sunumu kaydeder
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **VBA Makrolarını Çıkar**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun ve makro içeren sunumu yükleyin.
2. Sunumun bir VBA Projesi içerip içermediğini kontrol edin.
3. VBA Projesi içinde yer alan tüm modülleri dolaşarak makroları görüntüleyin.

Bu C++ kodu, makrolar içeren bir sunumdan VBA makrolarını nasıl çıkaracağınızı gösterir: 

```c++

	// Belgeler dizininin yolu.
	const String templatePath = u"../templates/VBA.pptm";

	// Makroyu içeren sunumu yükler
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Sunumun bir VBA Projesi içerip içermediğini kontrol eder
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```

## **VBA Projesinin Şifre Koruması Olup Olmadığını Kontrol Et**

[IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/tr/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) özelliğini kullanarak, bir projenin özelliklerinin şifre korumalı olup olmadığını belirleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve makro içeren bir sunumu yükleyin.
2. Sunumun bir [VBA project](https://reference.aspose.com/slides/tr/cpp/aspose.slides.vba/vbaproject/) içerip içermediğini kontrol edin.
3. VBA projesinin şifre korumalı olup olmadığını kontrol ederek özelliklerini görüntüleyin.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Sunumun bir VBA projesi içerip içermediğini kontrol edin.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **SSS**

**Sunumu PPTX olarak kaydedersem makrolar ne olur?**

Makrolar, PPTX VBA'yı desteklemediği için kaldırılacaktır. Makroları tutmak istiyorsanız PPTM, PPSM veya POTM formatlarından birini seçin.

**Aspose.Slides bir sunum içindeki makroları, örneğin veri yenilemek için çalıştırabilir mi?**

Hayır. Kütüphane VBA kodunu asla çalıştırmaz; yürütme yalnızca uygun güvenlik ayarlarına sahip PowerPoint içinde mümkündür.

**VBA koduna bağlı ActiveX denetimleriyle çalışmak destekleniyor mu?**

Evet, mevcut [ActiveX controls](/slides/tr/cpp/activex/) öğelerine erişebilir, özelliklerini değiştirebilir ve kaldırabilirsiniz. Bu, makroların ActiveX ile etkileşimde bulunduğu durumlarda faydalıdır.