---
title: Копирование абзаца и части в PPTX
type: docs
weight: 30
url: /cpp/copy-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Чтобы отформатировать текст презентации, нам нужно форматировать его на уровне **Абзаца** и **Части**. 
Некоторые свойства текста могут быть установлены на уровне абзаца, а некоторые - на уровне части. 
Если в тексте есть абзац или часть, которую нам нужно скопировать в вновь добавленные абзацы или части, нам нужно скопировать все свойства соответствующего абзаца или части в вновь добавленный абзац или часть.

{{% /alert %}} 

## **Копирование абзаца**
Свойства абзаца можно получить через экземпляр **ParagraphFormat** класса **Paragraph**. 
Нам нужно скопировать все свойства исходного абзаца в целевой абзац. В следующем примере представлен метод **CopyParagraph**, который принимает абзац для копирования в качестве аргумента. Он копирует все свойства исходного абзаца во временный абзац и возвращает его. Целевой абзац получает скопированные значения.

``` cpp
SharedPtr<Paragraph> CopyParagraph(SharedPtr<IParagraph> par)
{
	SharedPtr<Paragraph> para = MakeObject<Paragraph>();

	SharedPtr<IParagraphFormatEffectiveData> paraData = par->get_ParagraphFormat()->GetEffective();

	// используем ParagraphFormat, чтобы установить значения
	para->get_ParagraphFormat()->set_Alignment(paraData->get_Alignment());
	para->get_ParagraphFormat()->set_DefaultTabSize(paraData->get_DefaultTabSize());
	para->get_ParagraphFormat()->set_MarginLeft(paraData->get_MarginLeft());
	para->get_ParagraphFormat()->set_MarginRight(paraData->get_MarginRight());
	para->get_ParagraphFormat()->set_FontAlignment(paraData->get_FontAlignment());
	para->get_ParagraphFormat()->set_Indent(paraData->get_Indent());
	para->get_ParagraphFormat()->set_Depth(paraData->get_Depth());
	para->get_ParagraphFormat()->set_SpaceAfter(paraData->get_SpaceAfter());
	para->get_ParagraphFormat()->set_SpaceBefore(paraData->get_SpaceBefore());
	para->get_ParagraphFormat()->set_SpaceWithin(paraData->get_SpaceWithin());

	para->get_ParagraphFormat()->get_Bullet()->set_Type(paraData->get_Bullet()->get_Type());
	para->get_ParagraphFormat()->get_Bullet()->set_Char(paraData->get_Bullet()->get_Char());
	para->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(paraData->get_Bullet()->get_Color())  ;
	para->get_ParagraphFormat()->get_Bullet()->set_Height(paraData->get_Bullet()->get_Height()) ;
	para->get_ParagraphFormat()->get_Bullet()->set_Font(paraData->get_Bullet()->get_Font());
	para->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(paraData->get_Bullet()->get_NumberedBulletStyle());
	para->get_ParagraphFormat()->set_FontAlignment(paraData->get_FontAlignment()) ;

	para->get_ParagraphFormat()->set_RightToLeft(paraData->get_RightToLeft() ? NullableBool::True : NullableBool::False);
	para->get_ParagraphFormat()->set_EastAsianLineBreak(paraData->get_EastAsianLineBreak() ? NullableBool::True : NullableBool::False);
	para->get_ParagraphFormat()->set_HangingPunctuation(paraData->get_HangingPunctuation() ? NullableBool::True : NullableBool::False);

	return para;
}
```

## **Копирование части**
Свойства части можно получить через экземпляр **PortionFormat** класса **Portion**. 
Нам нужно скопировать все свойства исходной части в целевую часть. В следующем примере представлен метод **CopyPortion**, который принимает часть для копирования в качестве аргумента. Он копирует все свойства исходной части во временную часть и возвращает ее. Целевая часть получает скопированные значения.

``` cpp
SharedPtr<Portion> CopyPortion(SharedPtr<IPortion> por)
{
	SharedPtr<Portion> temp = MakeObject<Portion>();

	SharedPtr<IPortionFormatEffectiveData> portData = por->get_PortionFormat()->GetEffective();

	// используем PortionFormat, чтобы установить значения
	temp->get_PortionFormat()->set_AlternativeLanguageId(portData->get_AlternativeLanguageId());
	temp->get_PortionFormat()->set_BookmarkId(portData->get_BookmarkId()) ;
	temp->get_PortionFormat()->set_Escapement(portData->get_Escapement()) ;
	temp->get_PortionFormat()->get_FillFormat()->set_FillType(por->get_PortionFormat()->get_FillFormat()->get_FillType());
	temp->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(portData->get_FillFormat()->get_SolidFillColor()) ;

	temp->get_PortionFormat()->set_FontBold(portData->get_FontBold() ? NullableBool::True : NullableBool::False);
	temp->get_PortionFormat()->set_FontHeight(portData->get_FontHeight());
	temp->get_PortionFormat()->set_FontItalic(portData->get_FontItalic() ? NullableBool::True : NullableBool::False);
	temp->get_PortionFormat()->set_FontUnderline(portData->get_FontUnderline());
	temp->get_PortionFormat()->get_UnderlineFillFormat()->set_FillType(portData->get_UnderlineFillFormat()->get_FillType());
	temp->get_PortionFormat()->get_UnderlineFillFormat()->get_SolidFillColor()->set_Color(portData->get_UnderlineFillFormat()->get_SolidFillColor());
	temp->get_PortionFormat()->set_IsHardUnderlineFill(portData->get_IsHardUnderlineFill() ? NullableBool::True : NullableBool::False);
	temp->get_PortionFormat()->set_IsHardUnderlineLine(portData->get_IsHardUnderlineLine() ? NullableBool::True : NullableBool::False);

	temp->get_PortionFormat()->set_KerningMinimalSize(portData->get_KerningMinimalSize()) ;
	temp->get_PortionFormat()->set_Kumimoji(portData->get_Kumimoji() ? NullableBool::True : NullableBool::False);
	temp->get_PortionFormat()->set_LanguageId(portData->get_LanguageId());

	temp->get_PortionFormat()->set_LatinFont(portData->get_LatinFont()) ;
	temp->get_PortionFormat()->set_EastAsianFont(portData->get_EastAsianFont());
	temp->get_PortionFormat()->set_ComplexScriptFont(portData->get_ComplexScriptFont());
	temp->get_PortionFormat()->set_SymbolFont(portData->get_SymbolFont());

	temp->get_PortionFormat()->set_TextCapType(portData->get_TextCapType());
	temp->get_PortionFormat()->set_Spacing(portData->get_Spacing());
	temp->get_PortionFormat()->set_StrikethroughType(portData->get_StrikethroughType());
	temp->get_PortionFormat()->set_ProofDisabled(portData->get_ProofDisabled() ? NullableBool::True : NullableBool::False);
	temp->get_PortionFormat()->set_NormaliseHeight(portData->get_NormaliseHeight() ? NullableBool::True : NullableBool::False);
	temp->get_PortionFormat()->set_HyperlinkMouseOver(portData->get_HyperlinkMouseOver());
	temp->get_PortionFormat()->set_HyperlinkClick(por->get_PortionFormat()->get_HyperlinkClick());
	temp->get_PortionFormat()->get_HighlightColor()->set_Color(portData->get_HighlightColor());

	return temp;
}
```