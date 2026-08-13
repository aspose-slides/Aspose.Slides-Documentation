---
title: C++ Kullanarak Sunularda VBA Projelerini Yönetme
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
description: "Aspose.Slides for C++ ile VBA kullanarak PowerPoint ve OpenDocument sunumlarını oluşturma ve düzenleme yollarını keşfedin ve iş akışınızı kolaylaştırın."
---
## **Giriş**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Not" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **VBA Makroları Ekleme**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.vba.vba_project) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.vba.i_vba_project/) interface to manage VBA embedded in a presentation.

1. Presentation sınıfının bir örneğini oluşturun.
1. Yeni bir VBA projesi eklemek için VbaProject yapıcısını kullanın.
1. VbaProject'e bir modül ekleyin.
1. Modül kaynak kodunu ayarlayın.
1. <stdole> referansları ekleyin.
1. Microsoft Office referansları ekleyin.
1. Referansları VBA projesiyle ilişkilendirin.
1. Sunumu kaydedin.

This C++ code shows you how to add a VBA macro from scratch to a presentation: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaReferenceCollection.h>
#include <DOM/Vba/VbaProject.h>
#include <DOM/Vba/VbaReferenceOleTypeLib.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Vba;
using namespace System;

// Belgeler dizinine giden yol.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Sunum sınıfının bir örneğini oluşturur.
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Yeni bir VBA Projesi oluşturur.
presentation->set_VbaProject(MakeObject<VbaProject>());

// VBA projesine boş bir modül ekler.
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Modül kaynak kodunu ayarlar.
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// <stdole> referansı oluşturur.
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Office referansı oluşturur.
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBA projesine referanslar ekler.
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Sunumu kaydeder.
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="info" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/tr/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **VBA Makrolarını Kaldırma**

Using the [VbaProject](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) property under the [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) class, you can remove a VBA macro.

1. Presentation sınıfının bir örneğini oluşturun ve makro içeren sunumu yükleyin.
1. Macro modülüne erişin ve onu kaldırın.
1. Değiştirilen sunumu kaydedin.

This C++ code shows you how to remove a VBA macro: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// Belgeler dizinine giden yol.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Makroyu içeren sunumu yükler
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Vba modülüne erişir ve onu kaldırır
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Sunumu kaydeder
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **VBA Makrolarını Çıkartma**

1. Presentation sınıfının bir örneğini oluşturun ve makro içeren sunumu yükleyin.
2. Sunumun bir VBA Projesi içerip içermediğini kontrol edin.
3. VBA Projesinde bulunan tüm modülleri döngüye alarak makroları görüntüleyin.

This C++ code shows you how to extract VBA macros from a presentation containing macros: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

	// Belgeler dizinine giden yol.
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

## **Bir VBA Projesinin Şifre Koruması Olup Olmadığını Kontrol Etme**

Using the [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/tr/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) property, you can determine whether a project’s properties are password-protected.

1. Presentation sınıfının bir örneğini oluşturun ve bir makro içeren sunumu yükleyin.
2. Sunumun bir [VBA project](https://reference.aspose.com/slides/tr/cpp/aspose.slides.vba/vbaproject/) içerip içermediğini kontrol edin.
3. VBA projesinin şifre korumalı olup olmadığını kontrol ederek özelliklerini görüntüleyin.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Sunumun bir VBA projesi içerip içermediğini kontrol eder.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **SSS**

### Sunumu PPTX olarak kaydedersem makrolar ne olur?

Makrolar kaldırılacaktır çünkü PPTX VBA'yı desteklemez. Makroları tutmak için PPTM, PPSM veya POTM seçin.

### Aspose.Slides bir sunum içindeki makroları, örneğin verileri yenilemek gibi, çalıştırabilir mi?

Hayır. Kütüphane VBA kodunu asla çalıştırmaz; yürütme yalnızca uygun güvenlik ayarlarıyla PowerPoint içinde mümkündür.

### VBA koduna bağlanan ActiveX denetimleriyle çalışmak destekleniyor mu?

Evet, mevcut [ActiveX controls](/slides/tr/cpp/activex/) öğelerine erişebilir, özelliklerini değiştirebilir ve kaldırabilirsiniz. Bu, makroların ActiveX ile etkileşime girdiği durumlarda faydalıdır.