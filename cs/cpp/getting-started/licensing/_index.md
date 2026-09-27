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
description: "Aplikujte, spravujte a odstraňujte potíže s licencemi v Aspose.Slides pro C++. Zajistěte nepřerušený přístup k úplným funkcím pomocí našeho podrobného průvodce licencováním."
---
## **Přehled**

Aspose.Slides lze použít v režimu hodnocení nebo s platnou licencí. Hodnotící verze poskytuje stejnou funkčnost jako licencovaná verze, ale přidává hodnotící vodoznak na každou snímku každé prezentace, kterou uloží, a zkracuje text, který váš kód čte z prezentací.

Tento článek vysvětluje, jak funguje licencování v Aspose.Slides a jak aplikovat licenci před použitím knihovny. Licenci lze načíst ze souboru nebo proudu pomocí třídy `License`. Článek také ukazuje, jak ověřit, zda byla licence správně aplikována.

## **Vyzkoušejte Aspose.Slides**

{{% alert color="info" title="Poznámka" %}}
Můžete si stáhnout hodnotící verzi **Aspose.Slides for C++** z [její stránky ke stažení na NuGet](https://www.nuget.org/packages/Aspose.Slides.Cpp/) nebo, jako balíček ZIP, z [stránky ke stažení](https://releases.aspose.com/slides/cs/cpp/). Hodnotící verze nabízí stejnou funkčnost jako licencovaný produkt. Ve skutečnosti je hodnotící balíček totožný s zakoupeným – stačí přidat několik řádků kódu pro aplikaci licence a stane se licencovaným.

Jakmile budete spokojeni s hodnocením **Aspose.Slides**, můžete [zakoupit licenci](https://purchase.aspose.com/pricing/slides/cs/cpp/). Doporučujeme projít dostupné typy předplatného. Pokud máte jakékoli dotazy, neváhejte kontaktovat prodejní tým Aspose.

Každá licence Aspose zahrnuje roční předplatné na bezplatné aktualizace, včetně nových verzí a opravy chyb vydávaných během tohoto období. Ať už používáte licencovanou nebo hodnotící verzi, získáte bezplatnou a neomezenou technickou podporu.
{{% /alert %}} 

**Omezení hodnotící verze**

* Hodnotící verze (bez specifikované licence) poskytuje plnou funkčnost produktu, ale přidává textové pole s hodnotícím vodoznakem na každou snímku každé prezentace, kterou uloží.
* Text, který váš kód čte z prezentace, je zkrácen na první několik znaků, následované upozorněním o omezení hodnocení. Text, který váš kód zapisuje, je uložen v plném rozsahu.

{{% alert color="info" title="Poznámka" %}}
Pro testování Aspose.Slides bez omezení můžete požádat o **30denní dočasnou licenci**. Další informace naleznete na stránce [Jak získat dočasnou licenci](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licencování v Aspose.Slides**

* Hodnotící verze se stane licencovanou po zakoupení licence a jejím aplikováním přidáním několika řádků kódu.
* Licence je prostý textový soubor XML, který obsahuje podrobnosti jako název produktu, počet vývojářů, pro které je licence určena, datum vypršení předplatného a další.
* Soubor licence je digitálně podepsán, takže ho nesmí být upravován. I náhodná změna – například přidání zalomení řádku – soubor neplatní.
* Když předáte název souboru bez složky, Aspose.Slides for C++ hledá soubor licence pouze v aktuálním pracovním adresáři. Neprohledává složku vašeho spustitelného souboru ani složku knihovny Aspose.Slides, takže pokud je soubor licence uložen jinde, předávejte plnou cestu.
* Aby se zabránilo omezením hodnotící verze, musíte nastavit licenci před použitím Aspose.Slides. Licence stačí nastavit jen jednou pro aplikaci nebo proces.

## **Použití licence**

Licenci lze načíst ze **souboru** nebo **proudu**.

{{% alert color="info" title="Poznámka" %}}
Aspose.Slides poskytuje třídu [License](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/) pro operace s licencemi.
{{% /alert %}} 

{{% alert color="warning" title="Varování" %}}
Nové licence mohou aktivovat Aspose.Slides pouze s verzí 21.4 nebo novější. Starší verze používají jiný licenční systém a tyto licence nepoznají.
{{% /alert %}}

### **Soubor**

Nejjednodušší způsob, jak nastavit licenci, je umístit soubor licence do pracovního adresáře vašeho programu a zadat pouze název souboru, bez cesty. Jinak zadejte úplnou cestu k souboru.

Následující C++ kód aplikuje soubor licence *Aspose.Slides.lic* z pracovního adresáře programu:
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

Pokud je licence platná, [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) vrátí a program skončí bez výstupu; od té chvíle Aspose.Slides funguje bez omezení hodnocení. Pokud soubor není v pracovním adresáři, metoda vyhodí [FileNotFoundException](https://reference.aspose.com/slides/cs/cpp/system.io/filenotfoundexception/) s hláškou *License "Aspose.Slides.lic" doesn't exist or access is restricted*. Příklad výjimku neobsluhuje, takže program se zastaví.

{{% alert color="warning" title="Varování" %}}
Pokud umístíte soubor licence do jiného adresáře, pak při volání metody [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) musí název souboru na konci zadané explicitní cesty přesně odpovídat názvu vašeho souboru licence.

Například pokud přejmenujete soubor licence na *Aspose.Slides.lic.xml*, musíte do metody [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) v kódu předat úplnou cestu končící *Aspose.Slides.lic.xml*.
{{% /alert %}}

### **Proud**

Načtěte licenci z proudu, když váš program neuchovává licenci jako soubor, který lze pojmenovat, například při čtení licence z databáze. [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) přijímá libovolný [Stream](https://reference.aspose.com/slides/cs/cpp/system.io/stream/) obsahující licenci. Pro stručnost příkladu následující C++ kód otevře *Aspose.Slides.lic* v pracovním adresáři pomocí [File::OpenRead](https://reference.aspose.com/slides/cs/cpp/system.io/file/openread/) a aplikuje licenci z tohoto proudu:
```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Platná licence dává stejný výsledek jako v příkladu se souborem. Pokud soubor neexistuje, [File::OpenRead](https://reference.aspose.com/slides/cs/cpp/system.io/file/openread/) vyhodí [FileNotFoundException](https://reference.aspose.com/slides/cs/cpp/system.io/filenotfoundexception/) před aplikací licence a program se zastaví.

## **Ověření licence**

Pro kontrolu, zda byla licence správně nastavená, zavolejte [License::IsLicensed](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/islicensed/). Vrátí `true` pouze po aplikaci platné licence a `false` předtím. Následující C++ kód aplikuje soubor licence z pracovního adresáře a poté jej zkontroluje:
```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

S platnou licencí program vypíše *License is good!*. Pokud soubor chybí nebo není licenčním souborem, [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) vyhodí výjimku před kontrolou a program se zastaví bez výstupu. Pokud je soubor licencí, jejíž podpis neodpovídá, například protože byl upraven, SetLicense vrátí bez chyby, ale `IsLicensed` vrátí `false`, takže se nic nevyprintuje a Aspose.Slides zůstane v režimu hodnocení.

## **Bezpečnost vláken**

{{% alert color="warning" title="Varování" %}}
Metoda [License::SetLicense](https://reference.aspose.com/slides/cs/cpp/aspose.slides/license/setlicense/) není **thread-safe**. Pokud potřebujete tuto metodu volat souběžně z více vláken, doporučuje se použít synchronizační primitiva (například zámek) k prevenci možných problémů.
{{% /alert %}}

## **FAQ**

### Mohu aplikovat licenci v zcela offline prostředí (bez přístupu k internetu)?
Ano. Ověření licence probíhá lokálně pomocí souboru licence; není vyžadováno internetové připojení.

### Co se stane po vypršení ročního předplatného? Přestane knihovna fungovat?
Ne. Licence je trvalá: můžete i nadále používat verze vydané před datem konce vašeho předplatného; jen nebudete mít nárok na novější vydání bez prodloužení.