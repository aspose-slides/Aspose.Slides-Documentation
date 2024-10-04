---
title: Copiar Párrafo y Porción en PPTX
type: docs
weight: 30
url: /es/cpp/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Para formatear el texto de la presentación, necesitamos formatearlo a nivel de **Párrafo** y **Porción**. 
Algunas propiedades de texto se pueden establecer a nivel de Párrafo y otras a nivel de Porción. 
Si hay un párrafo o porción en el texto que necesitamos copiar a los párrafos o porciones recién agregados, necesitamos copiar todas las propiedades del párrafo o porción respectivo al párrafo o porción recién agregado.

{{% /alert %}} 

## **Copiar Párrafo**
Las propiedades del párrafo se pueden acceder a través de la instancia **ParagraphFormat** de la clase **Paragraph**. 
Necesitamos copiar todas las propiedades del párrafo fuente al párrafo objetivo. En el siguiente ejemplo, se comparte el método **CopyParagraph** que toma un párrafo a ser copiado como argumento. Copia todas las propiedades del párrafo fuente a un párrafo temporal y devuelve el mismo. El párrafo objetivo recibe los valores copiados.

``` cpp
SharedPtr<Paragraph> CopyParagraph(SharedPtr<IParagraph> par)
{
	SharedPtr<Paragraph> para = MakeObject<Paragraph>();

	SharedPtr<IParagraphFormatEffectiveData> paraData = par->get_ParagraphFormat()->GetEffective();

	// usar ParagraphFormat para establecer valores
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

## **Copiar Porción**
Las propiedades de la porción se pueden acceder a través de la instancia **PortionFormat** de la clase **Portion**. 
Necesitamos copiar todas las propiedades de la porción fuente a la porción objetivo. En el siguiente ejemplo, se comparte el método **CopyPortion** que toma una porción a ser copiada como argumento. Copia todas las propiedades de la porción fuente a una porción temporal y devuelve el mismo. La porción objetivo recibe los valores copiados.

``` cpp
SharedPtr<Portion> CopyPortion(SharedPtr<IPortion> por)
{
	SharedPtr<Portion> temp = MakeObject<Portion>();

	SharedPtr<IPortionFormatEffectiveData> portData = por->get_PortionFormat()->GetEffective();

	// usar PortionFormat para establecer valores
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