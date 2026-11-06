---
title: Správa komentářů prezentace v C++
linktitle: Komentáře prezentace
type: docs
weight: 100
url: /cs/cpp/presentation-comments/
keywords:
- komentář
- moderní komentář
- komentáře PowerPoint
- komentáře prezentace
- komentáře snímků
- přidat komentář
- přístup k komentáři
- upravit komentář
- odpovědět na komentář
- odstranit komentář
- smazat komentář
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Spravujte komentáře prezentace pomocí Aspose.Slides pro C++: přidávejte, čtěte, upravujte, odpovídejte a odstraňujte komentáře v prezentacích PowerPoint rychle a snadno."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat komentáře prezentace pomocí Aspose.Slides pro C++. Představuje hlavní typy související s komentáři a ukazuje, jak přidávat komentáře do snímků, přistupovat k existujícím komentářům, pracovat s odpověďmi a moderními komentáři a odstraňovat komentáře z prezentace.

Příklady pokrývají běžné scénáře revize a spolupráce v PowerPointu, jako je přiřazování komentářů autorům, čtení textu komentáře a metadat, vytváření řetězců odpovědí a odstraňování vybraných komentářů nebo všech komentářů.

V PowerPointu se komentáře zobrazují jako anotace na snímcích. Výběrem komentáře se zobrazí jeho text a související diskuze.

Chcete-li požádat, aby se komentáře zobrazovaly nebo skrývaly při otevření prezentace bez změny samotných komentářů, podívejte se na [Zobrazit nebo skrýt komentáře při otevírání prezentace](/slides/cs/cpp/presentation-view-properties/).

## **Proč přidávat komentáře do prezentací?**

Komentáře můžete použít k poskytování zpětné vazby a spolupráci s kolegy při revizi prezentací.

Aspose.Slides pro C++ poskytuje následující rozhraní API pro práci s komentáři:

* Třída [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), která poskytuje přístup k autorům komentářů prezentace.
* Rozhraní [ICommentCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/), které představuje komentáře spojené s jednotlivým autorem.
* Rozhraní [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/), které poskytuje informace o komentáři, včetně jeho autora, času vytvoření, pozice a textu.
* Třída [CommentAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/commentauthor/), která poskytuje informace o autorovi, včetně jeho jména, iniciál a souvisejících komentářů.

## **Přidat komentáře ke snímkům**

Příklad vytvoří dva snímky a zaregistruje autora komentáře pomocí [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/). Používá [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) k umístění jednoho komentáře na každý snímek, poté získá komentáře prvního snímku pro tohoto autora pomocí [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/). Konzole zobrazí text prvního komentáře dvakrát, čímž demonstruje přístup jak přes snímek, tak přes autora, a uložená prezentace obsahuje oba komentáře.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlide(0));

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");
auto position = PointF(0.2f, 0.2f);
auto createdTime = DateTime::get_Now();

author->get_Comments()->AddComment(u"Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
author->get_Comments()->AddComment(u"Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

auto comments = firstSlide->GetSlideComments(author);
if (comments->get_Length() > 0)
{
    auto firstComment = comments[0];
    Console::WriteLine(firstComment->get_Text());

    auto commentText = firstComment->get_Author()->get_Comments()->idx_get(0)->get_Text();
    Console::WriteLine(commentText);
}

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);
```

## **Najít nebo vytvořit autora komentáře**

Když automatizovaná revize opakovaně zpracovává stejnou prezentaci, vyhledejte v kolekci vrácené metodou [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/) před přidáním autora. [FindByNameAndInitials](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbynameandinitials/) porovnává jak jméno, tak iniciály a vrací pole odpovídajících autorů, nebo prázdné pole, pokud neexistují žádné shody. Naopak [FindByName](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/findbyname/) vyhledává pouze podle jména, bez ohledu na iniciály. Volání [AddAuthor](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/addauthor/) s jménem a iniciály, které již v kolekci jsou, vyvolá výjimku.

Příklad vyžaduje soubor prezentace s alespoň jedním snímkem. V každém ze dvou průchodů znovu použije prvního odpovídajícího autora nebo vytvoří nového pouze v případě, že je výsledek prázdný. Pokud existuje více shod, vybere první prvek pole bez sloučení nebo odstraňování ostatních autorů. Poté zavolá [AddComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addcomment/) pro vybraného autora a uloží prezentaci. Druhý průchod otevře výstup prvního průchodu a operaci zopakuje.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String authorName = u"Reviewer";
const String authorInitials = u"RV";

auto inputFile = String(u"input.pptx");
auto position = PointF(20.0f, 20.0f);

for (auto pass = 1; pass <= 2; pass++)
{
    auto presentation = MakeObject<Presentation>(inputFile);

    auto matches = presentation->get_CommentAuthors()->FindByNameAndInitials(authorName, authorInitials);

    auto author = matches->get_Length() > 0 ? matches[0] : presentation->get_CommentAuthors()->AddAuthor(authorName, authorInitials);
    author->get_Comments()->AddComment(u"Please review this slide.", presentation->get_Slide(0), position, DateTime::get_Now());

    auto outputFile = String::Format(u"review_pass_{0}.pptx", pass);
    presentation->Save(outputFile, SaveFormat::Pptx);
    inputFile = outputFile;
}
```

Druhý průchod přidá další komentář, aniž by přidal dalšího autora nebo odstraňoval existující komentáře. Konečný soubor, `review_pass_2.pptx`, obsahuje oba nové komentáře vedle všech původních komentářů. Opakované použití autora nededuplicuje komentáře: abyste se vyhnuli opakovanému přidávání stejného komentáře, implementujte samostatnou detekci duplicit před jeho přidáním.

## **Přístup ke komentářům snímků**

Příklad otevře existující prezentaci a načte kolekci vrácenou metodou [get_CommentAuthors](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_commentauthors/). Pro každého autora prochází kolekci vrácenou metodou [get_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthor/get_comments/) a vypisuje číslo snímku, text komentáře, jméno autora a čas vytvoření. Vstupní prezentace musí obsahovat komentáře, aby byl vyprodukován výstup do konzole.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    for (auto&& comment : author->get_Comments())
    {
        Console::WriteLine(u"Slide: {0}", comment->get_Slide()->get_SlideNumber());
        Console::WriteLine(u"Comment: {0}", comment->get_Text());
        Console::WriteLine(u"Author: {0}", comment->get_Author()->get_Name());
        Console::WriteLine(u"Posted at: {0}", comment->get_CreatedTime());
        Console::WriteLine();
    }
}
```

## **Odpovídat na komentáře**

Rodičovský komentář je původní komentář na vrcholu hierarchie odpovědí. Metody [get_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/get_parentcomment/) a [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) rozhraní [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) umožňují získat nebo nastavit rodiče komentáře.

Příklad vytvoří komentáře od dvou autorů a používá [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) k vytvoření odpovědí, včetně odpovědi na další odpověď. Předání `nullptr` metodě [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) načte komentáře od všech autorů; konzole odsazuje každý záznam podle jeho hloubky v hierarchii odpovědí. Příklad uloží kompletní diskuzi, zavolá [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) na první kořenový komentář a uloží druhou prezentaci s tímto komentářem a jeho odpověďmi odebranými.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto position = PointF(10.0f, 10.0f);
auto createdTime = DateTime::get_Now();

auto originalAuthor = presentation->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto rootComment = originalAuthor->get_Comments()->AddComment(u"comment 1", slide, position, createdTime);

auto reviewer = presentation->get_CommentAuthors()->AddAuthor(u"Author_2", u"B.B.");
auto firstReply = reviewer->get_Comments()->AddComment(u"reply 1 for comment 1", slide, position, createdTime);
firstReply->set_ParentComment(rootComment);

auto secondReply = reviewer->get_Comments()->AddComment(u"reply 2 for comment 1", slide, position, createdTime);
secondReply->set_ParentComment(rootComment);

auto subReply = originalAuthor->get_Comments()->AddComment(u"subreply 3 for reply 2", slide, position, createdTime);
subReply->set_ParentComment(secondReply);

reviewer->get_Comments()->AddComment(u"comment 2", slide, position, createdTime);
auto separateComment = reviewer->get_Comments()->AddComment(u"comment 3", slide, position, createdTime);

auto separateReply = originalAuthor->get_Comments()->AddComment(u"reply 4 for comment 3", slide, position, createdTime);
separateReply->set_ParentComment(separateComment);

auto comments = slide->GetSlideComments(nullptr);
for (auto i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::WriteLine(u"{0}: {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
}

presentation->Save(u"parent_comment.pptx", SaveFormat::Pptx);

rootComment->Remove();
presentation->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
* Když je metoda [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/remove/) rozhraní [IComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/) použita k odstranění komentáře, všechny odpovědi na tento komentář jsou také odstraněny.
* Pokud metoda [set_ParentComment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/) vytvoří kruhový odkaz, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/).
{{% /alert %}}

## **Přidat moderní komentáře**

Moderní komentáře mohou být přiřazeny k samotnému snímku, k určitému tvaru nebo k rozsahu textu uvnitř AutoShape. Metoda [ICommentCollection::AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) přijímá argument [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) kromě snímku a souřadnic značky komentáře.

Když je pro argument shape předáno `nullptr`, komentář je na úrovni snímku. Jeho značka je umístěna podle zadaných souřadnic, ale není přiřazena k žádnému konkrétnímu tvaru, takže [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) vrací `nullptr`. Když je poskytnut [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), je komentář ukotven k tomuto tvaru. Souřadnice stále určují pozici značky komentáře na snímku, zatímco přiřazení tvaru lze získat pomocí [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/).

### **Ukotvit moderní komentář k tvaru**

Příklad zavolá [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) dvakrát: jednou s tvarem `nullptr` pro komentář na úrovni snímku a podruhé s obdélníkem jako kotvou. Volání [get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/) vypíše `True` pro kontrolu null u komentáře na úrovni snímku a `Revenue title` pro ukotvený komentář. Oba komentáře jsou uloženy s prezentací.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 300.0f, 80.0f);
shape->set_Name(u"Revenue title");
shape->get_TextFrame()->set_Text(u"Quarterly revenue");

auto createdTime = DateTime::get_Now();
auto slideCommentPosition = PointF(20.0f, 20.0f);
auto shapeCommentPosition = PointF(60.0f, 60.0f);
auto slideComment = author->get_Comments()->AddModernComment(u"Review the overall slide layout.", slide, nullptr, slideCommentPosition, createdTime);
auto shapeComment = author->get_Comments()->AddModernComment(u"Check this title.", slide, shape, shapeCommentPosition, createdTime);

Console::WriteLine(slideComment->get_Shape() == nullptr);
auto shapeAnchor = shapeComment->get_Shape();
if (shapeAnchor != nullptr)
{
    Console::WriteLine(shapeAnchor->get_Name());
}

presentation->Save(u"modern_comments.pptx", SaveFormat::Pptx);
```

### **Ukotvit komentáře k různým typům tvarů**

Jakýkoli objekt snímku, který implementuje [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), může být použit jako kotva tvaru. Běžné příklady zahrnují [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/cpp/aspose.slides/iconnector/), a instance [IGraphicalObject](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobject/), jako jsou grafy.

Příklad používá [AddModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/addmoderncomment/) k přiřazení komentáře ke každému z pěti typů tvarů: AutoShape, rámečku obrázku, skupině, propojení a grafu. Obrázek používá vložená data obrázku, takže není vyžadován žádný externí obrázek. Každý komentář má vlastní pozici značky a uložená prezentace zachovává všech pět přiřazení tvarů.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IConnector.h>
#include <DOM/IGroupShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/convert.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto createdTime = DateTime::get_Now();

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 60.0f);
autoShape->get_TextFrame()->set_Text(u"AutoShape");

auto autoShapeCommentPosition = PointF(30.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

auto imageBase64 = u"iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
auto imageData = Convert::FromBase64String(imageBase64);
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 120.0f, 80.0f, image);
auto pictureCommentPosition = PointF(230.0f, 30.0f);
author->get_Comments()->AddModernComment(u"Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

auto groupShape = slide->get_Shapes()->AddGroupShape();
groupShape->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 80.0f, 40.0f);
groupShape->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 100.0f, 0.0f, 80.0f, 40.0f);
auto groupCommentPosition = PointF(40.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 220.0f, 150.0f, 140.0f, 40.0f);
auto connectorCommentPosition = PointF(240.0f, 150.0f);
author->get_Comments()->AddModernComment(u"Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 400.0f, 20.0f, 250.0f, 180.0f);
auto chartCommentPosition = PointF(420.0f, 40.0f);
author->get_Comments()->AddModernComment(u"Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

presentation->Save(u"modern_comment_shape_types.pptx", SaveFormat::Pptx);
```

### **Ukotvit komentář k textu a nastavit jeho stav**

Pro moderní komentář spojený s [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/) a [IModernComment::set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/) řídí počáteční pozici vybraného textu v textovém rámečku tvaru. Podobně [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/) a [IModernComment::set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) řídí délku výběru. Společně tyto metody přiřazují komentář ke konkrétnímu rozsahu textu uvnitř AutoShape.

[IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) a [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) používají hodnotu z výčtu [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/):

- `NotDefined` — není definován žádný konkrétní stav moderního komentáře.
- `Active` — komentář je aktivní.
- `Resolved` — komentář byl vyřešen.
- `Closed` — komentář je uzavřen.

Příklad ukotví moderní komentář k slovům „quarterly revenue“ v textu obdélníku. Vypočítá nulový počáteční index výběru z textu, předá jej metodě [set_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionstart/), a zavolá [set_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_textselectionlength/) s počtem vybraných znaků. Po volání [set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) s hodnotou `Resolved` prezentaci uloží a znovu otevře. Čtyři kontroly v konzoli by měly každá vypsat `True`, což potvrzuje, že kotva tvaru, textový rozsah a stav byly zachovány.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

const String outputFile = u"modern_comment_text_anchor.pptx";
const String shapeText = u"Review the quarterly revenue forecast.";
const String selectedText = u"quarterly revenue";
auto expectedSelectionStart = shapeText.IndexOf(selectedText);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 100.0f);
shape->set_Name(u"Forecast text");
shape->get_TextFrame()->set_Text(shapeText);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Reviewer", u"RV");
auto commentPosition = PointF(60.0f, 60.0f);
auto comment = author->get_Comments()->AddModernComment(u"Verify this forecast wording.", slide, shape, commentPosition, DateTime::get_Now());
comment->set_TextSelectionStart(expectedSelectionStart);
comment->set_TextSelectionLength(selectedText.get_Length());
comment->set_Status(ModernCommentStatus::Resolved);

presentation->Save(outputFile, SaveFormat::Pptx);

auto reopenedPresentation = MakeObject<Presentation>(outputFile);
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedComments = reopenedSlide->GetSlideComments(nullptr);

for (auto&& reopenedComment : reopenedComments)
{
    auto modernComment = AsCast<IModernComment>(reopenedComment);
    if (modernComment == nullptr)
    {
        continue;
    }

    auto shapeAnchor = modernComment->get_Shape();
    auto shapeMatches = shapeAnchor != nullptr && shapeAnchor->get_Name() == u"Forecast text";
    auto selectionStartMatches = modernComment->get_TextSelectionStart() == expectedSelectionStart;
    auto selectionLengthMatches = modernComment->get_TextSelectionLength() == selectedText.get_Length();
    auto statusMatches = modernComment->get_Status() == ModernCommentStatus::Resolved;

    Console::WriteLine(u"Shape anchor preserved: {0}", shapeMatches);
    Console::WriteLine(u"Text selection start preserved: {0}", selectionStartMatches);
    Console::WriteLine(u"Text selection length preserved: {0}", selectionLengthMatches);
    Console::WriteLine(u"Resolved status preserved: {0}", statusMatches);
}
```

### **Prohlédnout existující moderní komentáře**

Příklad vyžaduje existující prezentaci obsahující moderní komentáře a vypisuje jejich text, stav a podrobnosti o kotvě. Pro jejich prohlédnutí zkontrolujte, které komentáře implementují [IModernComment](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/), poté prozkoumejte [IModernComment::get_Shape](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_shape/), [IModernComment::get_TextSelectionStart](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionstart/), [IModernComment::get_TextSelectionLength](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_textselectionlength/), a [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/). Tvar `nullptr` označuje komentář na úrovni snímku. Pro kotvu [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) metody výběru textu určují související rozsah v textovém rámečku tvaru.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IComment.h>
#include <DOM/IModernComment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ModernCommentStatus.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"comments.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto comments = slide->GetSlideComments(nullptr);
    for (auto&& comment : comments)
    {
        auto modernComment = AsCast<IModernComment>(comment);
        if (modernComment == nullptr)
        {
            continue;
        }

        Console::WriteLine(u"Slide: {0}", slide->get_SlideNumber());
        Console::WriteLine(u"Text: {0}", modernComment->get_Text());
        Console::WriteLine(u"Status: {0}", modernComment->get_Status());

        auto shape = modernComment->get_Shape();
        if (shape == nullptr)
        {
            Console::WriteLine(u"Anchor: slide level");
        }
        else
        {
            Console::WriteLine(u"Anchor shape: {0}", shape->get_Name());
            Console::WriteLine(u"Anchor type: {0}", shape->GetType().get_Name());

            auto autoShape = AsCast<IAutoShape>(shape);
            if (autoShape != nullptr)
            {
                Console::WriteLine(u"Text selection start: {0}", modernComment->get_TextSelectionStart());
                Console::WriteLine(u"Text selection length: {0}", modernComment->get_TextSelectionLength());
            }
        }

        Console::WriteLine();
    }
}
```

## **Odstranit komentáře**

Aspose.Slides pro C++ umožňuje odstranit všechny komentáře a jejich autory z prezentace nebo smazat vybrané komentáře a přitom zachovat ostatní. Následující příklady ukazují oba přístupy a ukládají aktualizovanou prezentaci.

### **Odstranit všechny komentáře a autory komentářů**

Příklad otevře existující prezentaci a pro každého autora zavolá [ICommentCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/clear/), poté zavolá [ICommentAuthorCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icommentauthorcollection/clear/) aby odstranil samotné autory. Uložená prezentace neobsahuje ani komentáře, ani autory komentářů. Použijte prezentaci obsahující komentáře, abyste pozorovali odstranění.

```cpp
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"example.pptx");

for (auto&& author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}

presentation->get_CommentAuthors()->Clear();

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

### **Odstranit konkrétní komentáře**

Příklad vytvoří dva komentáře na jednom snímku a používá [GetSlideComments](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getslidecomments/) k nalezení komentářů od každého autora. Shromažďuje komentáře, jejichž text se rovná „comment 1“, před voláním [ICommentCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icommentcollection/remove/), aby se během výběru zabránilo změnám v kolekci. Uložená prezentace zachová jen „comment 2“.

```cpp
#include <DOM/IComment.h>
#include <DOM/ICommentAuthor.h>
#include <DOM/ICommentAuthorCollection.h>
#include <DOM/ICommentCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
auto createdTime = DateTime::get_Now();

auto firstCommentPosition = PointF(0.2f, 0.2f);
auto secondCommentPosition = PointF(0.3f, 0.2f);
author->get_Comments()->AddComment(u"comment 1", slide, firstCommentPosition, createdTime);
author->get_Comments()->AddComment(u"comment 2", slide, secondCommentPosition, createdTime);

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto commentsToRemove = MakeObject<List<SharedPtr<IComment>>>();
    auto comments = slide->GetSlideComments(commentAuthor);

    for (auto&& comment : comments)
    {
        if (comment->get_Text() == u"comment 1")
        {
            commentsToRemove->Add(comment);
        }
    }

    for (auto&& comment : commentsToRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}

presentation->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Podporuje Aspose.Slides stav vyřešeno pro moderní komentáře?**

Ano. [IModernComment::get_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/get_status/) a [IModernComment::set_Status](https://reference.aspose.com/slides/cpp/aspose.slides/imoderncomment/set_status/) používají hodnotu z [ModernCommentStatus](https://reference.aspose.com/slides/cpp/aspose.slides/moderncommentstatus/), včetně `Resolved`. Stav je uložen v prezentaci a lze jej znovu přečíst po opětovném otevření souboru.

**Jsou podporovány vlákna diskuzí (řetězce odpovědí) a existuje limit na hloubku vnoření?**

Ano. Každý komentář může odkazovat na svůj [parent comment](https://reference.aspose.com/slides/cpp/aspose.slides/icomment/set_parentcomment/), což umožňuje řetězce odpovědí. API nedefinuje konkrétní limit hloubky vnoření.

**V jakém souřadnicovém systému je definována pozice značky komentáře na snímku?**

Pozice značky je definována pomocí souřadnic s desetinnou čárkou v souřadnicovém systému snímku, což umožňuje její přesné umístění na snímku.