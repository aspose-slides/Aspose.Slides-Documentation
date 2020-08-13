---
title: Aspose.Slides for Java 18.8 Release Notes
type: docs
weight: 50
url: /java/aspose-slides-for-java-18-8-release-notes/
---

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESJAVA-37312|Exception on using Fonts|Investigation|
|SLIDESJAVA-37132|[Use Aspose.Slides for Net 18.8 features](https://docs.aspose.com/display/slidesnet/Aspose.Slides+for+.NET+18.8+Release+Notes)|Feature|
|SLIDESNET-40224|Add support for Strict Open XML format|Feature|
|SLIDESNET-34155|Add support for Strict Open XML format|Feature|
|SLIDESNET-40189|Rendering of Metafiles ignores fonts loaded with FontsLoader|Feature|
|SLIDESNET-40304|Rendering comments from ODP format that have no author|Bug|
|SLIDESNET-39229|Support for "purl.oclc.org" namespace in Type attribute in ".rels" parts|Bug|
|SLIDESJAVA-37028|PPT to PDF not properly converted Enterprise Support|Enhancement|
|SLIDESJAVA-37290|Icons are missing in exported PDF for RedHat Linux|Enhancement|
## **Public API Changes**
#### **getShowCommentsByNoAuthor and setShowCommentsByNoAuthor methods have been added to INotesCommentsLayoutingOptions**
getShowCommentsByNoAuthor() and setShowCommentsByNoAuthor(boolean) methods have been added to INotesCommentsLayoutingOptions.

Specifies the visibility of comments that do not have an author.

By default getShowCommentsByNoAuthor() return false, which means that comments without authors are not displayed.

{{< highlight java >}}

 Presentation pres = new Presentation("no-author.odp");

try

{

PdfOptions options = new PdfOptions();

options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

options.getNotesCommentsLayouting().setShowCommentsByNoAuthor(true);

pres.save("out_pres.pdf", SaveFormat.Pdf, options);

}

finally {

pres.dispose();

}

{{< /highlight >}}



h4. getShowCommentsByNoAuthor and setShowCommentsByNoAuthor methods have been added to INotesCommentsLayoutingOptions 

getShowCommentsByNoAuthor() and setShowCommentsByNoAuthor(boolean) methods have been added to INotesCommentsLayoutingOptions. 

Specifies the visibility of comments that do not have an author. 

By default getShowCommentsByNoAuthor() return false, which means that comments without authors are not displayed. 

{code} 
Presentation pres = new Presentation("no-author.odp"); 
try 
{ 
PdfOptions options = new PdfOptions(); 
options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right); 
options.getNotesCommentsLayouting().setShowCommentsByNoAuthor(true); 
pres.save("out_pres.pdf", SaveFormat.Pdf, options); 
} 
finally { 
pres.dispose(); 
} 
{code}
