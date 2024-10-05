---
title: PPTXにおける段落と部分のコピー
type: docs
weight: 30
url: /cpp/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

プレゼンテーションのテキストをフォーマットするためには、**段落**と**部分**レベルでフォーマットする必要があります。
段落レベルで設定できるテキストプロパティと、部分レベルで設定できるテキストプロパティがあります。
テキストにコピーする必要がある段落または部分がある場合、該当する段落または部分のすべてのプロパティを新しく追加された段落または部分にコピーする必要があります。

{{% /alert %}} 

## **段落のコピー**
段落プロパティは、**Paragraph**クラスの**ParagraphFormat**インスタンスを通じてアクセスできます。
ソース段落のすべてのプロパティをターゲット段落にコピーする必要があります。次の例では、コピーする段落を引数として受け取る**CopyParagraph**メソッドを示します。ソース段落のすべてのプロパティを一時的な段落にコピーし、それを返します。ターゲット段落はコピーされた値を取得します。

``` cpp
SharedPtr<Paragraph> CopyParagraph(SharedPtr<IParagraph> par)
{
	SharedPtr<Paragraph> para = MakeObject<Paragraph>();

	SharedPtr<IParagraphFormatEffectiveData> paraData = par->get_ParagraphFormat()->GetEffective();

	// ParagraphFormatを使用して値を設定
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

## **部分のコピー**
部分プロパティは、**Portion**クラスの**PortionFormat**インスタンスを通じてアクセスできます。
ソース部分のすべてのプロパティをターゲット部分にコピーする必要があります。次の例では、コピーする部分を引数として受け取る**CopyPortion**メソッドを示します。ソース部分のすべてのプロパティを一時的な部分にコピーし、それを返します。ターゲット部分はコピーされた値を取得します。

``` cpp
SharedPtr<Portion> CopyPortion(SharedPtr<IPortion> por)
{
	SharedPtr<Portion> temp = MakeObject<Portion>();

	SharedPtr<IPortionFormatEffectiveData> portData = por->get_PortionFormat()->GetEffective();

	// PortionFormatを使用して値を設定
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