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
- zkušební verze
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Použijte, spravujte a řešte problémy s licencemi v Aspose.Slides pro C++. Zajistěte nepřerušený přístup k plným funkcím pomocí našeho podrobného průvodce licencováním."
---
## **Přehled**

Aspose.Slides lze používat v režimu zkušební verze nebo s platnou licencí. Zkušební verze poskytuje stejnou funkčnost jako licencovaná verze, ale přidává vodoznak pro hodnocení při otevírání nebo ukládání prezentací a omezuje extrakci textu na jeden snímek.

Tento článek vysvětluje, jak funguje licencování v Aspose.Slides a jak aplikovat licenci před použitím knihovny. Licenci lze načíst ze souboru, proudu nebo vloženého zdroje pomocí třídy `License`. Článek také ukazuje, jak ověřit, zda byla licence použita správně.

## **Vyzkoušejte Aspose.Slides**

{{% alert color="primary" %}} 

Můžete si stáhnout zkušební verzi **Aspose.Slides for C++** z [její stránky ke stažení na NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). Zkušební verze nabízí stejnou funkčnost jako licencovaný produkt. Ve skutečnosti je zkušební balíček identický s zakoupeným – stačí přidat několik řádků kódu pro aplikaci licence a stane se licencovaným.

Jakmile budete spokojeni se zkušební verzí **Aspose.Slides**, můžete [zakoupit licenci](https://purchase.aspose.com/buy). Doporučujeme si projít dostupné typy předplatného. Pokud máte jakékoli otázky, neváhejte kontaktovat prodejní tým Aspose.

Každá licence Aspose zahrnuje roční předplatné na bezplatné aktualizace, včetně nových verzí a opravy chyb vydaných během tohoto období. Ať už používáte licencovanou nebo zkušební verzi, získáte bezplatnou a neomezenou technickou podporu.

{{% /alert %}} 

**Omezení zkušební verze**

* Zatímco zkušební verze Aspose.Slides (když není licence použita) poskytuje plnou funkčnost produktu, během operací otevření a uložení vkládá vodoznak pro hodnocení v horní části dokumentu.
* Extrakce textu je omezená na jeden snímek při použití zkušební verze.

{{% alert color="primary" %}} 

Pro testování Aspose.Slides bez omezení můžete požádat o **30denní dočasnou licenci**. Další informace najdete na stránce [Jak získat dočasnou licenci](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licencování v Aspose.Slides**

* Zkušební verze se po zakoupení licence a jejím použitím přidáním několika řádků kódu promění v licencovanou.
* Licence je textový XML soubor, který obsahuje podrobnosti jako název produktu, počet vývojářů, pro které je licence určena, datum vypršení předplatného a další.
* Licenční soubor je digitálně podepsaný, takže nesmí být upravován. I náhodná změna – například přidání nového řádku – soubor neplatní.
* Aspose.Slides for C++ obvykle hledá licenční soubor na následujících místech:
  * Cesta explicitně uvedená ve vašem kódu
  * Složka obsahující DLL komponenty (součást Aspose.Slides)
  * Složka obsahující sestavu, která volá DLL komponenty
* Aby se zabránilo omezením zkušební verze, musíte licenci nastavit před použitím Aspose.Slides. Licence je potřeba nastavit jen jednou za aplikaci nebo proces.

## **Použití licence**

Licence může být načtena ze **souboru**, **proudu** nebo **vloženého zdroje**.

{{% alert color="primary" %}}

Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.license/) pro operace s licencemi.

{{% /alert %}} 

{{% alert color="warning" %}}

Nové licence mohou aktivovat Aspose.Slides pouze s verzí 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.

{{% /alert %}}

### **File**

Nejjednodušší způsob, jak nastavit licenci, je umístit licenční soubor do stejné složky jako DLL komponenty (součást Aspose.Slides) a uvést pouze název souboru bez cesty.

Následující C++ kód ukazuje, jak nastavit licenční soubor:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Pokud umístíte licenční soubor do jiné složky, pak při volání metody [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) musí název souboru na konci zadané explicitní cesty přesně odpovídat názvu vašeho licenčního souboru.

Například pokud přejmenujete licenční soubor na *Aspose.Slides.lic.xml*, musíte do metody [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) ve svém kódu předat úplnou cestu končící *Aspose.Slides.lic.xml*.

{{% /alert %}}

### **Stream**

Můžete načíst licenci z proudu. Následující C++ kód ukazuje, jak aplikovat licenci z proudu:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Validate a License**

Pro kontrolu, zda byla licence nastavena správně, ji můžete ověřit. Následující C++ kód ukazuje, jak validovat licenci:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

Metoda [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) **není thread‑safe**. Pokud potřebujete tuto metodu volat současně z více vláken, je doporučeno použít synchronizační primitiva (například zamykání), aby se předešlo možným problémům.

{{% /alert %}}

## **FAQ**

**Mohu licenci použít v zcela offline prostředí (bez přístupu k internetu)?**

Ano. Ověření licence probíhá lokálně pomocí licenčního souboru; není vyžadováno žádné internetové připojení.

**Co se stane po vypršení ročního předplatného? Přestane knihovna fungovat?**

Ne. Licence je trvalá: můžete nadále používat verze vydané před datem vypršení předplatného; prostě nebudete mít nárok na novější vydání bez obnovení.