---
title: Správa uzlů tvaru SmartArt v prezentacích pomocí C++
linktitle: Uzel tvaru SmartArt
type: docs
weight: 30
url: /cs/cpp/manage-smartart-shape-node/
keywords:
- Uzel SmartArt
- Poduzel
- Přidat uzel
- Pozice uzlu
- Přístup k uzlu
- Odstranit uzel
- Vlastní pozice
- Asistenční uzel
- Formát výplně
- Vykreslení uzlu
- PowerPoint
- Prezentace
- C++
- Aspose.Slides
description: Spravujte uzly tvaru SmartArt v PPT a PPTX pomocí Aspose.Slides pro C++. Získejte přehledné ukázky kódu a tipy pro zjednodušení vašich prezentací.
---
## **Přehled**

Grafika SmartArt v prezentacích PowerPoint je organizována pomocí uzlů, které obsahují text a definují strukturu diagramu. Aspose.Slides vám umožňuje pracovat s těmito uzly SmartArt programově: přidávat nové uzly a poduzly, vkládat poduzly na konkrétní pozici, přistupovat k existujícím uzlům a číst jejich text, úroveň a pozici.

Tento článek vysvětluje, jak spravovat uzly tvarů SmartArt. Ukazuje, jak odstranit uzly, pracovat s poduzly podle indexu nebo pozice, změnit asistenční uzel na běžný uzel, upravit pozici, velikost a rotaci tvarů uzlu SmartArt, nastavit formáty výplně uzlu a vygenerovat miniaturu obrázku pro poduzel SmartArt.

## **Přidat uzel SmartArt**
Aspose.Slides pro C++ poskytuje nejjednodušší API pro správu tvarů SmartArt nejjednodušším způsobem. Následující ukázkový kód pomůže přidat uzel a poduzel do tvaru SmartArt.

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a přetypujte vybraný tvar na SmartArt, pokud je SmartArt.
- Přidejte nový uzel do kolekce NodeCollection tvaru SmartArt a nastavte text v TextFrame.
- Nyní přidejte poduzel do nově přidaného uzlu SmartArt a nastavte text v TextFrame.
- Uložte prezentaci.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Přidat uzel SmartArt na konkrétní pozici**
V následujícím ukázkovém kódu vysvětlujeme, jak přidat poduzly patřící k jednotlivým uzlům tvaru SmartArt na konkrétní pozici.

- Vytvořte instanci třídy `Presentation`.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Přidejte tvar SmartArt typu StackedList do získaného snímku.
- Získejte první uzel v přidaném tvaru SmartArt.
- Nyní přidejte poduzel pro vybraný uzel na pozici 2 a nastavte jeho text.
- Uložte prezentaci.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **Přístup k uzlu SmartArt**
Následující ukázkový kód pomůže přistupovat k uzlům uvnitř tvaru SmartArt. Všimněte si, že nemůžete změnit LayoutType SmartArt, protože je pouze pro čtení a je nastaven pouze při přidání tvaru SmartArt.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a přetypujte vybraný tvar na SmartArt, pokud je SmartArt.
- Projděte všechny uzly uvnitř tvaru SmartArt.
- Získejte a zobrazte informace, jako je pozice uzlu SmartArt, úroveň a text.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Přístup k poduzlu SmartArt**
Následující ukázkový kód pomůže přistupovat k poduzlům patřícím k jednotlivým uzlům tvaru SmartArt.

- Vytvořte instanci třídy PresentationEx a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a přetypujte vybraný tvar na SmartArtEx, pokud je SmartArt.
- Projděte všechny uzly uvnitř tvaru SmartArt.
- Pro každý vybraný uzel tvaru SmartArt projděte všechny poduzly v daném uzlu.
- Získejte a zobrazte informace, jako je pozice poduzlu, úroveň a text.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Přístup k poduzlu SmartArt na konkrétní pozici**
V tomto příkladu se naučíme přistupovat k poduzlům na konkrétní pozici, které patří k jednotlivým uzlům tvaru SmartArt.

- Vytvořte instanci třídy `Presentation`.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Přidejte tvar SmartArt typu StackedList.
- Získejte přidaný tvar SmartArt.
- Získejte uzel s indexem 0 pro získaný tvar SmartArt.
- Nyní přistupte k poduzlu na pozici 1 pro získaný uzel SmartArt pomocí metody GetNodeByPosition().
- Získejte a zobrazte informace, jako je pozice poduzlu, úroveň a text.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Odstranit uzel SmartArt**
V tomto příkladu se naučíme odstranit uzly uvnitř tvaru SmartArt.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a přetypujte vybraný tvar na SmartArt, pokud je SmartArt.
- Zkontrolujte, zda má SmartArt více než 0 uzlů.
- Vyberte uzel SmartArt, který má být odstraněn.
- Nyní odstraňte vybraný uzel pomocí metody RemoveNode()* Uložte prezentaci.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Odstranit uzel SmartArt na konkrétní pozici**
V tomto příkladu se naučíme odstranit uzly uvnitř tvaru SmartArt na konkrétní pozici.

- Vytvořte instanci třídy `Presentation` a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na první snímek pomocí jeho Indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a přetypujte vybraný tvar na SmartArt, pokud je SmartArt.
- Vyberte uzel tvaru SmartArt s indexem 0.
- Nyní zkontrolujte, zda vybraný uzel SmartArt má více než 2 poduzly.
- Nyní odstraňte uzel na pozici 1 pomocí metody RemoveNodeByPosition().
- Uložte prezentaci.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Nastavit vlastní pozici pro poduzel SmartArt**
Nyní Aspose.Slides podporuje nastavení vlastností X a Y pro SmartArtShape. Níže uvedený úryvek kódu ukazuje, jak nastavit vlastní pozici, velikost a rotaci SmartArtShape; také je třeba poznamenat, že přidání nových uzlů způsobí přepočet pozic a velikostí všech uzlů.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Zkontrolovat asistenční uzel**
V následujícím ukázkovém kódu prozkoumáme, jak identifikovat asistenční uzly ve sbírce uzlů SmartArt a jak je změnit.

- Vytvořte instanci třídy PresentationEx a načtěte prezentaci se SmartArt tvarem.
- Získejte odkaz na druhý snímek pomocí jeho Indexu.
- Projděte všechny tvary v prvním snímku.
- Zkontrolujte, zda je tvar typu SmartArt, a přetypujte vybraný tvar na SmartArtEx, pokud je SmartArt.
- Projděte všechny uzly uvnitř tvaru SmartArt a zkontrolujte, zda jsou asistenční uzly.
- Změňte stav asistenčního uzlu na normální uzel.
- Uložte prezentaci.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Nastavit výplňový formát uzlu**
Aspose.Slides pro C++ umožňuje přidávat vlastní tvary SmartArt a nastavit jejich výplňové formáty. Tento článek vysvětluje, jak vytvořit a přistupovat k tvarům SmartArt a nastavit jejich výplňový formát pomocí Aspose.Slides pro C++.

Postupujte podle následujících kroků:

- Vytvořte instanci třídy `Presentation`.
- Získejte odkaz na snímek pomocí jeho indexu.
- Přidejte tvar SmartArt nastavením jeho LayoutType.
- Nastavte FillFormat pro uzly tvaru SmartArt.
- Uložte upravenou prezentaci jako soubor PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **Vytvořit miniaturu poduzlu SmartArt**
Vývojáři mohou vygenerovat miniaturu poduzlu SmartArt následujícím postupem:

1. Vytvořte instanci třídy `Presentation`, která představuje soubor PPTX.
2. Přidejte SmartArt.
3. Získejte odkaz na uzel pomocí jeho Indexu.
4. Získejte obrázek miniatury.
5. Uložte obrázek miniatury v libovolném požadovaném formátu obrázku.

Níže uvedený příklad generuje miniaturu poduzlu SmartArt

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Často kladené otázky**

**Je animace SmartArt podporována?**

Ano. SmartArt je považován za běžný tvar, takže můžete [použít standardní animace](/slides/cs/cpp/shape-animation/) (vstupní, výstupní, zdůrazňovací, trajektorie pohybu) a upravit časování. V případě potřeby můžete animovat i tvary uvnitř uzlů SmartArt.

**Jak mohu spolehlivě najít konkrétní SmartArt na snímku, pokud je jeho interní ID neznámé?**

Přiřaďte a vyhledejte pomocí [alternativního textu](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/set_alternativetext/). Nastavení výrazného AltTextu na SmartArt vám umožní najít jej programově bez spoléhání se na interní identifikátory.

**Zůstane vzhled SmartArt zachován při konverzi prezentace do PDF?**

Ano. Aspose.Slides vykresluje SmartArt s vysokou vizuální věrností během [exportu do PDF](/slides/cs/cpp/convert-powerpoint-to-pdf/), zachovává rozvržení, barvy a efekty.

**Mohu extrahovat obrázek celého SmartArt (pro náhledy nebo zprávy)?**

Ano. Můžete vykreslit tvar SmartArt do [rastrých formátů](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/getimage/) nebo do [SVG](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/writeassvg/) pro škálovatelný vektorový výstup, což je vhodné pro miniatury, zprávy nebo webové použití.