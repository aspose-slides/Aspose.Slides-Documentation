---
title: Licencování
description: "Použijte licenční soubor pro Aspose.Slides for Node.js via .NET, zjistěte omezení verze pro hodnocení a získejte bezplatnou 30-denní dočasnou licenci pro testování."
type: docs
weight: 80
url: /cs/nodejs-net/licensing/
---
## **Přehled**

Aspose.Slides for Node.js via .NET je jeden npm balíček jak pro hodnocení, tak pro produkci. Bez licence běží v režimu hodnocení. Po zakoupení licence nebo získání bezplatné 30‑denní dočasné licence ji použijete pomocí několika řádků kódu a omezení hodnocení již neplatí.

{{% alert color="info" title="Note" %}}
Obecné zásady, jak hodnotit, licencovat a nakupovat produkty Aspose, jsou shromážděny v [Zásady nákupu a FAQ](https://purchase.aspose.com/policies). Ceny jsou uvedeny na stránce [Informace o cenách](https://purchase.aspose.com/pricing/slides/cs/family).
{{% /alert %}}

## **Omezení verze hodnocení**

Verze pro hodnocení poskytuje plnou funkčnost produktu, s dvěma omezeními:

- **Watermark.** Každý snímek každé prezentace, kterou uložíte, získá hodnocený vodoznak: uzamčené textové pole uprostřed snímku s textem „Pouze pro hodnocení.“ Stejný vodoznak se vykresluje ve výstupech PDF, XPS a HTML a na obrázcích snímků.
- **Truncated text.** Text, který váš kód načte zpět z textového rámce, odstavce nebo části, je oříznut na prvních pět znaků, následovaný upozorněním “… text has been truncated due to evaluation version limitation.” Exporty do Markdown a HTML5 jsou zkráceny stejným způsobem. Text, který váš kód zapisuje, je uložen celý.

[Vyhodnotit Aspose.Slides](/slides/cs/nodejs-net/evaluate-aspose-slides/) popisuje obě omezení podrobně a obsahuje skript, který je ukazuje.

{{% alert color="success" title="Tip" %}}
Pro testování Aspose.Slides bez omezení hodnocení požádejte o bezplatnou **30‑denní dočasnou licenci**. Podrobnosti najdete v [How to get a Temporary License?](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **O licenci**

Licence je soubor XML v prostém textu, který obsahuje podrobnosti jako název produktu, počet vývojářů, pro které je licence určena, a datum vypršení předplatného. Soubor je digitálně podepsán, proto jej nechte beze změn: i zbytečný řádkový zlomak přidaný omylem ho zneplatní.

## **Použití licence**

Licenci použijte metodou `setLicense` třídy `License`. Zavolejte ji jednou na proces, před tím než vytvoříte jakýkoli objekt `Presentation`. Opětovné volání neškodí, ale opakuje již provedenou práci.

Následující skript použije licenci ze souboru s názvem `Aspose.Slides.lic`. Nahraďte název názvem nebo úplnou cestou k vašemu licenčnímu souboru; soubor může mít libovolný název.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Název souboru nebo relativní cesta jsou vyhodnoceny vůči aktuální složce, ze které spouštíte `node`. Uchovejte licenční soubor ve složce projektu a spouštějte skripty odtud, nebo zadejte úplnou cestu.

Pokud soubor nelze najít nebo není platnou licencí, `setLicense` vyhodí chybu a Aspose.Slides zůstane v režimu hodnocení. Skript chybu zachytí a vypíše její zprávu. Pro chybějící soubor zpráva začíná `License "Aspose.Slides.lic" doesn't exist or access is restricted.` a uvádí každé místo, kde bylo hledáno.

V tomto balíčku se licence používá pouze ze souboru. `License` nepřijímá proud a balíček neumožňuje metrické licencování. Pro třídu, kterou balíček obaluje, viz [License](https://reference.aspose.com/slides/cs/net/aspose.slides/license/) v dokumentaci API Aspose.Slides pro .NET.