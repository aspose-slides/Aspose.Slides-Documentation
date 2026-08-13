---
title: Licencování
type: docs
weight: 120
url: /cs/cpp/licensing/
keywords:
- licence
- dočasná licence
- nastavit licenci
- použít licenci
- ověřit licenci
- licenční soubor
- hodnotící verze
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Aplikujte, spravujte a řešte problémy s licencemi v Aspose.Slides pro C++. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho krok za krokem průvodce licencováním."
---
## **Přehled**

Aspose.Slides lze používat v režimu hodnocení nebo s platnou licencí. Hodnotící verze poskytuje stejnou funkčnost jako licencovaná verze, ale při otevírání nebo ukládání prezentací přidává vodoznak hodnocení a omezuje extrakci textu na jeden snímek.

Tento článek vysvětluje, jak funguje licencování v Aspose.Slides a jak aplikovat licenci před použitím knihovny. Licenci lze načíst ze souboru, proudu nebo vloženého prostředku pomocí třídy `License`. Článek také ukazuje, jak ověřit, zda byla licence aplikována správně.

## **Vyzkoušet Aspose.Slides**

{{% alert color="info" %}} 

Můžete si stáhnout hodnotící verzi **Aspose.Slides for C++** z [její stránky ke stažení na NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). Hodnotící verze nabízí stejnou funkčnost jako licencovaný produkt. Ve skutečnosti je hodnotící balíček identický s zakoupeným – stačí jen přidat několik řádků kódu pro aplikaci licence.

Jakmile budete s **Aspose.Slides** spokojeni, můžete [zakoupit licenci](https://purchase.aspose.com/buy). Doporučujeme si prohlédnout dostupné typy předplatného. Pokud máte jakékoli otázky, neváhejte kontaktovat prodejní tým Aspose.

Každá licence Aspose obsahuje jednoletý odběr pro bezplatné aktualizace, včetně nových verzí a oprav chyb vydaných během tohoto období. Ať už používáte licencovanou nebo hodnotící verzi, získáte bezplatnou a neomezenou technickou podporu.

{{% /alert %}} 

**Omezení hodnotící verze**

* Zatímco hodnotící verze Aspose.Slides (když není licence aplikována) poskytuje plnou funkčnost produktu, vkládá vodotisk hodnocení v horní části dokumentu během operací otevření a uložení.
* Extrakce textu je omezena na jeden snímek při používání hodnotící verze.

{{% alert color="info" %}} 

Pro testování Aspose.Slides bez omezení můžete požádat o **30denní dočasnou licenci**. Další informace naleznete na stránce [Jak získat dočasnou licenci](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licencování v Aspose.Slides**

* Hodnotící verze se po zakoupení licence a jejím aplikování několika řádky kódu stane licencovanou.
* Licence je prostý textový soubor XML, který obsahuje podrobnosti jako název produktu, počet vývojářů, pro které je licence udělena, datum vypršení předplatného a další.
* Licenční soubor je digitálně podepsán, proto nesmí být upravován. I neúmyslná změna – například přidání konce řádku – soubor neplatí.
* Aspose.Slides for C++ typicky hledá licenční soubor na následujících místech:
  * Cesta výslovně zadána ve vašem kódu
  * Složka obsahující DLL komponenty (součást Aspose.Slides)
  * Složka obsahující sestavu, která volá DLL komponenty
* Aby bylo možné obejít omezení hodnotící verze, musíte nastavit licenci před použitím Aspose.Slides. Licence se nastavuje jen jednou na aplikaci nebo proces.

## **Aplikovat licenci**

Licence může být načtena ze **souboru**, **proudu** nebo **vloženého prostředku**.

{{% alert color="info" %}}

Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.license/) pro operace s licencí.

{{% /alert %}} 

{{% alert color="warning" %}}

Nové licence mohou aktivovat Aspose.Slides pouze od verze 21.4 a novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.

{{% /alert %}}

### **Soubor**

Nejjednodušší způsob nastavení licence je umístit licenční soubor do stejné složky jako DLL komponenty (součást Aspose.Slides) a zadat pouze název souboru, bez cesty.

Následující kód C++ ukazuje, jak nastavit licenční soubor:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Pokud umístíte licenční soubor do jiné složky, pak při volání metody [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) musí název souboru na konci zadané explicitní cesty přesně odpovídat názvu vašeho licenčního souboru.

Například pokud přejmenujete váš licenční soubor na *Aspose.Slides.lic.xml*, musíte do metody [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) ve svém kódu předat úplnou cestu končící na *Aspose.Slides.lic.xml*.

{{% /alert %}}

### **Proud**

Licence může být načtena ze streamu. Následující kód C++ ukazuje, jak aplikovat licenci ze streamu:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Ověřit licenci**

Pro kontrolu, zda je licence nastavena správně, ji můžete ověřit. Následující kód C++ ukazuje, jak ověřit licenci:

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Bezpečnost při práci ve vláknech**

{{% alert title="Note" color="warning" %}} 

Metoda [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) **není bezpečná pro více vláken**. Pokud potřebujete tuto metodu volat současně z více vláken, doporučuje se použít synchronizační primitiva (například zámek), aby se předešlo možným problémům.

{{% /alert %}}

## **Často kladené otázky**

### Mohu aplikovat licenci v zcela offline prostředí (bez přístupu k internetu)?

Ano. Ověření licence probíhá lokálně pomocí licenčního souboru; není vyžadováno žádné připojení k internetu.

### Co se stane po vypršení jednoletého předplatného? Přestane knihovna fungovat?

Ne. Licence je trvalá: můžete nadále používat verze vydané před datem konce předplatného; jen nebudete mít nárok na novější vydání bez obnovení předplatného.