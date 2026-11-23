---
title: Automatizujte personalizaci prezentací pomocí hromadné korespondence
linktitle: Hromadná korespondence
type: docs
weight: 233
url: /cs/net/mail-merge/
keywords:
- Hromadná korespondence
- personalizace prezentací
- šablona prezentace
- textové zástupce
- datový zdroj
- CSV
- Excel
- XLSX
- JSON
- XML
- sloučit data
- generovat prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak použít hromadnou korespondenci v Aspose.Slides pro .NET k naplnění šablon prezentací daty a generování personalizovaných prezentací PowerPoint z CSV, Excel, JSON a XML zdrojů."
---
## **Hromadná korespondence v prezentacích PowerPoint**

Aspose.Slides pro .NET vám umožňuje automaticky generovat prezentace PowerPoint pomocí šablony a datového zdroje. Hromadná korespondence vyplní zástupce v šabloně daty a vytvoří buď jedinou prezentaci obsahující opakované snímky šablony pro každý datový soubor, nebo samostatnou prezentaci pro každý datový soubor.

Tato funkce je užitečná pro generování katalogů produktů, personalizovaných prezentací, zpráv, certifikátů, návrhů, ceníků a dalších dokumentů, kde struktura prezentace zůstává stejná, zatímco obsah se liší.

![Mail Merge: před a po](mail-merge-before-after.png)


## **Jak funguje hromadná korespondence**

Hromadná korespondence používá prezentaci PowerPoint jako šablonu a nahrazuje zástupce hodnotami z datového zdroje.

![Mail Merge workflow](mail-merge-workflow.png)

Zástupce je název pole uzavřený ve dvojitých složených závorkách, například `{{title}}` nebo `{{price}}`. Zástupci mohou být umístěni v textu ve tvarech, buňkách tabulek, seskupených tvarech i v poznámkách přednášejícího.

Například snímek šablony může obsahovat následující text:

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

Když datový zdroj obsahuje následující hodnoty:

| Pole | Hodnota |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14‑inch display, 16 GB RAM |

Hromadná korespondence nahradí zástupce odpovídajícími hodnotami a vytvoří snímek s reálnými údaji o produktu.

Názvy polí nejsou citlivé na velikost písmen, takže `{{title}}` a `{{Title}}` odkazují na stejné pole.

Platí následující pravidla při nahrazování zástupců:

- Zástupci jsou nahrazeni na snímcích, včetně seskupených tvarů a buněk tabulek, a v poznámkách přednášejícího.
- Zástupci na hlavních snímcích a rozvržení snímků nejsou nahrazeni.
- Zástupce, jehož pole není v datovém souboru přítomno, zůstane beze změny.
- Prázdná hodnota pole nahradí jeho zástupce prázdným řetězcem.
- Vložený text zdědí formátování prvního znaku zástupce.
- Hodnoty nesmí obsahovat text zástupce, protože vložený text může být znovu zpracován a nahrazen jiným polem.

Původní šablona prezentace není během operace sloučení upravena a musí obsahovat alespoň jeden snímek.

## **Podporované datové zdroje**

Hromadná korespondence podporuje dva způsoby zadávání dat:

- Vytvořit datový zdroj programově pomocí `IMailMergeDataSource`.
- Načíst data ze souboru nebo proudu CSV, XLSX, JSON nebo XML.

Formát dat je detekován podle obsahu, ne podle přípony souboru. Podporovány jsou i proudy, které neumožňují hledání.

Datový zdroj musí obsahovat alespoň jeden datový soubor. Každý datový soubor představuje jednu kopii šablony, která bude vyplněna jeho hodnotami.

Pokud obsah dat nemůže být rozpoznán jako podporovaný formát, je vyhozena výjimka `NotSupportedException`. Pokud je obsah rozpoznán, ale nesplňuje požadavky formátu, je vyhozena výjimka `InvalidDataException`. Zpráva výjimky obsahuje umístění chyby v datech.

### **JSON**

Datový zdroj JSON musí mít kořenový objekt obsahující pole `sets`. Každý prvek pole představuje datový soubor a musí obsahovat pole `fields`. Každé pole musí mít řetězce `name` a `value`.

Volitelná vlastnost `version` musí být `"1.0"` a volitelná vlastnost `type` pole musí být `"text"`. Názvy vlastností rozlišují velká a malá písmena. Neznámé vlastnosti jsou ignorovány.

JSON data jsou čtena jako UTF‑8 nebo jako UTF‑16, pokud data začínají značkou BOM.

Následující příklad obsahuje dva datové soubory:

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### **XML**

Datový zdroj XML musí mít kořenový element `template`, který obsahuje element `sets`. Každý element `set` obsahuje elementy `field`, a každý `field` musí obsahovat elementy `name` a `value`.

Prázdný element `value` se interpretuje jako prázdný řetězec. Názvy elementů rozlišují velká a malá písmena. Neznámé elementy a komentáře jsou ignorovány. Kódování je určeno deklarací XML. Definice typu dokumentu (DTD) nejsou povoleny.

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### **CSV**

CSV data používají středník jako oddělovač hodnot.

První řádek obsahuje názvy polí a končí při prvním prázdném názvu pole. Každý následující řádek představuje jeden datový soubor. Data končí při první prázdné řádce.

Platí následující pravidla:

- Chybějící hodnoty na konci řádku se berou jako prázdné řetězce.
- Hodnoty nad rámec definovaných názvů polí jsou ignorovány.
- Hodnota obsahující středník, uvozovky nebo zalomení řádku musí být uzavřena v uvozovkách.
- Uvozovky uvnitř uvozované hodnoty musí být zdvojené.
- Data jsou čtena jako UTF‑8 nebo jako UTF‑16, pokud začínají značkou BOM.

Příklad:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

Data XLSX jsou čtena z první pracovní tabulky.

Pracovní list řídí stejná pravidla jako CSV:

- První řádek obsahuje názvy polí a končí při první prázdné buňce.
- Každý následující řádek představuje jeden datový soubor.
- Data končí při první prázdné řádce.
- Prázdné buňky jsou považovány za prázdné řetězce.
- Číselné hodnoty jsou převedeny na text pomocí invariantní kultury.

## **Vytvoření jedné prezentace**

Metoda `MergeToSinglePresentation` vytvoří jednu prezentaci obsahující kopii snímků šablony pro každý datový soubor. Každá kopie je vyplněna odpovídajícími daty.

Pořadí datových souborů určuje pořadí skupin snímků ve výsledné prezentaci.

### **Sloučení dat ze souboru**

Následující příklad načte šablonu a soubor JSON s daty, vytvoří jednu prezentaci obsahující snímky pro všechny datové soubory a výsledek uloží.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Data mohou být také načtena z proudu. Proud je čten od jeho aktuální pozice a není uzavřen operací hromadné korespondence.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### **Vytvoření datového zdroje v kódu**

Můžete vytvořit datový zdroj programově pomocí `MailMergeDataSource` a `MailMergeDataSet`. Přidejte datový soubor pro každý záznam a definujte jeho pole pomocí metody `AddText`.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

V tomto příkladu jsou snímky šablony opakovány dvakrát: jednou pro notebook a jednou pro tablet. Zástupci jsou vyplněni hodnotami definovanými v každém datovém souboru.

## **Vytvoření více prezentací**

Pokud potřebujete samostatnou prezentaci pro každý datový soubor, použijte metodu `MergeToMultiplePresentations`.

Tato metoda zpracovává datové soubory jeden po druhém, vytvoří prezentaci ze šablony, vyplní ji aktuálními daty a předá výslednou prezentaci obsluze.

Obsluha je volána jednou pro každý datový soubor v původním pořadí dat.

### **Ukládání každé prezentace**

Následující příklad načte data ze souboru CSV a uloží každou vygenerovanou prezentaci jako samostatný soubor.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

Vlastnost `args.Index` poskytuje nulový index aktuálního datového souboru. V příkladu se používá k vytvoření sekvenčních názvů souborů počínaje `product_1.pptx`.

Data mohou být také načtena z proudu:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### **Použití hodnot datových souborů pro pojmenování souborů**

Obsluha získá jak vygenerovanou prezentaci, tak informace o datovém souboru, který byl použit. Můžete použít hodnoty datových souborů k vytvoření smysluplných názvů souborů.

Například následující kód ukládá každou prezentaci pomocí názvu produktu:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

Vlastnost `DataSet` vrací datový soubor použitý k vyplnění aktuální prezentace. Metoda `GetText` získá hodnotu zadaného pole nebo `null`, pokud pole není přítomno.

To vám umožní použít hodnoty dat pro pojmenování souborů, organizaci výstupu nebo další zpracování v obsluze.

## **Zpracování vygenerovaných prezentací**

`MergeToMultiplePresentations` používá delegáta `MailMergedPresentationHandler` pro zpracování každé vygenerované prezentace.

Obsluha přijímá dva argumenty:

- `presentation` — prezentace vytvořená ze šablony a vyplněná aktuálním datovým souborem.
- `args` — informace o vygenerované prezentaci, včetně indexu datového souboru a samotného souboru.

Vygenerovaná prezentace patří operaci hromadné korespondence a je uvolněna okamžitě po návratu z obsluhy. Proto ji musíte uložit nebo zkopírovat potřebná data uvnitř obsluhy. Neukládejte na ni odkaz po návratu z obsluhy ani ji neodstraňujte ručně.

Obsluha je spuštěna na volajícím vlákně, jedna prezentace po druhé, v pořadí datových souborů. V paměti je uložena vždy jen jedna vygenerovaná prezentace, což činí tento přístup vhodným pro zpracování velkých datových zdrojů bez nutnosti držet všechny prezentace v paměti současně.

Pokud obsluha vyvolá výjimku, operace hromadné korespondence se zastaví a výjimka je předána volajícímu beze změny. Prezentace, které již byly zpracovány, zůstávají nedotčeny a zbývající datové soubory nejsou zpracovány.

Následující příklad ukládá vygenerované prezentace do vyhrazeného adresáře:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## **Práce s daty hromadné korespondence**

Třída `MailMergeDataSource` představuje uspořádanou kolekci datových souborů. Lze ji použít k vytvoření dat v kódu, ke kontrole počtu datových souborů a k přístupu k jednotlivým souborům podle indexu.

### **Získání počtu datových souborů**

Vlastnost `Count` vrací počet datových souborů v zdroji.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Přístup k datovému souboru podle indexu**

Vlastnost `Item(int)` poskytuje přístup k datovému souboru na zadaném nulovém indexu.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Tento příklad získá název druhého datového souboru.

### **Přidání textových polí**

Metoda `AddText` přidá pojmenované textové pole do datového souboru. Hodnota pole nahradí všechny odpovídající zástupce v šabloně.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Prázdná hodnota odstraní odpovídající zástupce z výsledného textu. Pokud pole do datového souboru není přidáno, zůstane zástupce beze změny.

### **Čtení textových polí**

Metoda `GetText` získá hodnotu pole podle názvu. Názvy polí nejsou citlivé na velikost písmen.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Pokud pole neexistuje nebo je zadán `null`, metoda `GetText` vrací `null`.

## **Shrnutí**

Hromadná korespondence v Aspose.Slides pro .NET poskytuje pohodlný způsob, jak generovat prezentace řízené daty z opakovaně použitelné šablony.

Můžete ji využít k:

- Vyplnění šablon prezentací hodnotami z datových zdrojů.
- Vytvoření jedné prezentace obsahující opakované snímky šablony pro více datových souborů.
- Vytvoření samostatné prezentace pro každý datový soubor.
- Načtení dat ze souborů nebo proudů CSV, XLSX, JSON a XML.
- Vytvoření datových zdrojů přímo v kódu.
- Sekvenčnímu zpracování a ukládání vygenerovaných prezentací pomocí obsluhy.

Kombinací opakovaně použitelných šablon a strukturovaných dat můžete automatizovat tvorbu velkého počtu prezentací a zároveň udržet design šablony a logiku zpracování dat oddělené.

## **Často kladené otázky**

**Mohu použít stejný zástupce vícekrát v šabloně?**

Ano. Každý výskyt zástupce se shodným názvem pole je nahrazen odpovídající hodnotou z aktuálního datového souboru.

**Jsou názvy polí citlivé na velikost písmen?**

Ne. Názvy zástupců i datových polí nejsou citlivé na velikost písmen. Například `{{title}}`, `{{Title}}` a `{{TITLE}}` odkazují na stejné pole.

**Co se stane, když v datovém souboru chybí pole?**

Pokud datový soubor neobsahuje pole, na které odkazuje zástupce, zůstane tento zástupce vygenerované prezentaci beze změny.

**Co se stane, když má pole prázdnou hodnotu?**

Prázdná hodnota pole nahradí zástupce prázdným řetězcem. Text zástupce je odstraněn a v jeho místě nezůstane žádný text.

**Mohu zachovat formátování zástupce při jeho nahrazení?**

Text, kterým je zástupce nahrazen, zdědí formátování prvního znaku zástupce. Přidejte požadované formátování přímo do textu zástupce ve šabloně před provedením sloučení.

**Nahrazuje hromadná korespondence zástupce na hlavních snímcích nebo rozvržení snímků?**

Ne. Hromadná korespondence nahrazuje zástupce jen v podporovaném obsahu na běžných snímcích (tvary, seskupené tvary, buňky tabulek, poznámky). Zástupci na hlavních snímcích a rozvržení snímků nejsou nahrazeni.

**Je šablona prezentace během sloučení upravena?**

Ne. Původní šablona není sloučením upravena. Můžete ji znovu použít k tvorbě dalších prezentací ze stejných či různých datových zdrojů.

**Mohu generovat samostatnou prezentaci pro každý datový soubor?**

Ano. Použijte `MergeToMultiplePresentations` a uložte každou vygenerovanou prezentaci v obsluze. Obsluha je volána sekvenčně pro každý datový soubor.

**Mohu sloučit všechny datové soubory do jedné prezentace?**

Ano. Použijte `MergeToSinglePresentation`. Vytvoří jedinou výstupní prezentaci obsahující kopii snímků šablony pro každý datový soubor v pořadí zdroje dat.

**Mohu použít datový zdroj bez jeho ukládání do souboru?**

Ano. Můžete vytvořit `MailMergeDataSource` v kódu, přidat datové soubory a naplnit pole pomocí `AddText`. To je užitečné, když jsou data již dostupná ve vaší aplikaci.

**Detekuje hromadná korespondence formát dat podle přípony souboru?**

Ne. Formát dat je detekován podle obsahu, takže podporovaný datový zdroj nemusí mít konkrétní příponu souboru.

**Mohu načíst data z proudu, který nepodporuje hledání?**

Ano. Hromadná korespondence podporuje nevyhledatelné proudy.

**Co se stane, když je datový zdroj prázdný nebo neobsahuje žádné datové soubory?**

Datový zdroj musí obsahovat alespoň jeden datový soubor. Ujistěte se, že před zahájením sloučení obsahuje alespoň jeden záznam.

**Co se stane, když má datový zdroj neplatný formát?**

Pokud obsah není rozpoznán jako jeden z podporovaných formátů, je vyhozena výjimka `NotSupportedException`. Pokud je rozpoznán, ale má nesprávnou strukturu, je vyhozena výjimka `InvalidDataException`. Zpráva výjimky uvádí informace o místě chyby.

**Mohu použít vygenerovanou prezentaci po návratu z obsluhy?**

Prezentace předaná obsluze `MergeToMultiplePresentations` patří hromadné korespondenci a je po návratu z obsluhy uvolněna. Uložte ji nebo zkopírujte potřebný obsah během obsluhy a neuchovávejte ani neodstraňujte tuto prezentaci ručně.

**Je obsluha volána paralelně?**

Ne. Vygenerované prezentace jsou zpracovávány sekvenčně na vlákně volajícího. V každém okamžiku je v paměti pouze jedna prezentace, což umožňuje zpracování velkých datových zdrojů bez nutnosti držet všechny prezentace najednou.

**Co se stane, když v obsluze dojde k výjimce?**

Operace sloučení se zastaví a výjimka je předána volajícímu beze změny. Prezentace, které již byly zpracovány, zůstávají nedotčeny a zbývající datové soubory nejsou zpracovány.

**Mohu použít hodnoty polí pro generování názvů výstupních souborů?**

Ano. Obsluha poskytuje aktuální datový soubor prostřednictvím argumentů. Použijte `GetText` k získání hodnot a vytvořte název souboru pro každou vygenerovanou prezentaci. Ujistěte se, že hodnoty jsou platné pro názvy souborů v cílovém prostředí.