---
title: スライドにコメントを追加する
type: docs
weight: 10
url: /net/add-a-comment-to-a-slide/
---

## **OpenXML プレゼンテーション:**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx"; 

AddCommentToPresentation(FileName,

"Zeeshan", "MZ",

"This is my programmatically added comment.");

// プレゼンテーションドキュメントの最初のスライドにコメントを追加します。

// プレゼンテーションドキュメントには少なくとも1つのスライドが含まれている必要があります。

private static void AddCommentToPresentation(string file, string initials, string name, string text)

{

using (PresentationDocument doc = PresentationDocument.Open(file, true))

{

    // CommentAuthorsPart オブジェクトを宣言します。

    CommentAuthorsPart authorsPart;

    // 既存のコメント著者パートがあるか確認します。

    if (doc.PresentationPart.CommentAuthorsPart == null)

    {

        // なければ、新しいものを追加します。

        authorsPart = doc.PresentationPart.AddNewPart<CommentAuthorsPart>();

    }

    else

    {

        authorsPart = doc.PresentationPart.CommentAuthorsPart;

    }

    // コメント著者パートにコメント著者リストがあるか確認します。

    if (authorsPart.CommentAuthorList == null)

    {

        // なければ、新しいものを追加します。

        authorsPart.CommentAuthorList = new CommentAuthorList();

    }

    // 新しい著者 ID を宣言します。

    uint authorId = 0;

    CommentAuthor author = null;

    // コメント著者リストに既存の子要素がある場合...

    if (authorsPart.CommentAuthorList.HasChildren)

    {

        // 渡された著者がリストにあるか確認します。

        var authors = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Where(a => a.Name == name && a.Initials == initials);

        // もしあれば...

        if (authors.Any())

        {

            // 新しいコメント著者に既存の著者 ID を割り当てます。

            author = authors.First();

            authorId = author.Id;

        }

        // そうでなければ...

        if (author == null)

        {

            // 渡された著者に新しい ID を割り当てます。

            authorId = authorsPart.CommentAuthorList.Elements<CommentAuthor>().Select(a => a.Id.Value).Max();

        }

    }

    // コメント著者リストに既存の子要素がない場合。

    if (author == null)

    {

        authorId++;

        // コメント著者リストに新しい子要素（コメント著者）を追加します。

        author = authorsPart.CommentAuthorList.AppendChild<CommentAuthor>

        (new CommentAuthor()

        {

            Id = authorId,

            Name = name,

            Initials = initials,

            ColorIndex = 0

        });

    }

    // 最初のスライドを取得し、GetFirstSlide メソッドを使用します。

    SlidePart slidePart1 = GetFirstSlide(doc);

    // コメントパートを宣言します。

    SlideCommentsPart commentsPart;

    // 最初のスライドパートにコメントパートがあるか確認します。

    if (slidePart1.GetPartsOfType<SlideCommentsPart>().Count() == 0)

    {

        // なければ、新しいコメントパートを追加します。

        commentsPart = slidePart1.AddNewPart<SlideCommentsPart>();

    }

    else

    {

        // そうでなければ、スライドパート内の最初のコメントパートを使用します。

        commentsPart = slidePart1.GetPartsOfType<SlideCommentsPart>().First();

    }

    // コメントリストが存在しない場合。

    if (commentsPart.CommentList == null)

    {

        // 新しいコメントリストを追加します。

        commentsPart.CommentList = new CommentList();

    }

    // 新しいコメント ID を取得します。

    uint commentIdx = author.LastIndex == null ? 1 : author.LastIndex + 1;

    author.LastIndex = commentIdx;

    // 新しいコメントを追加します。

    Comment comment = commentsPart.CommentList.AppendChild<Comment>(

    new Comment()

    {

        AuthorId = authorId,

        Index = commentIdx,

        DateTime = DateTime.Now

    });

    // コメント要素に位置の子ノードを追加します。

    comment.Append(

    new Position() { X = 100, Y = 200 },

    new Text() { Text = text });

    // コメント著者パートを保存します。

    authorsPart.CommentAuthorList.Save();

    // コメントパートを保存します。

    commentsPart.CommentList.Save();

}

}

// プレゼンテーションドキュメントの最初のスライドのスライドパートを取得します。

private static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// 最初のスライドのリレーションシップ ID を取得します。

PresentationPart part = presentationDocument.PresentationPart;

SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();

string relId = slideId.RelationshipId;

// リレーションシップ ID によってスライドパートを取得します。

SlidePart slidePart = (SlidePart)part.GetPartById(relId);

return slidePart;

}


``` 
## **Aspose.Slides**
**Aspose.Slides** for .NET では、PPT スライドコメントコレクションがすべての **Slide** クラスに含まれています。 **CommentCollection** クラスは特定のスライドコメントを保持するために使用されます。 **Comment** クラスには、スライドコメントを追加した著者、そのイニシャル、作成時間、スライド上のスライドコメントの位置、コメントテキストなどの情報が含まれています。 **CommentAuthor** クラスは、プレゼンテーションレベルでスライドコメントの著者を追加するために使用されます。 **Presentation** クラスは、**CommentAuthors** クラス内でプレゼンテーションの著者のコレクションを保持します。

以下の例では、スライドコメントを追加するためのコードスニペットを追加しました。

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Add a comment to a slide.pptx";

using (Presentation pres = new Presentation())

{

    //空のスライドを追加

    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    //著者を追加

    ICommentAuthor author = pres.CommentAuthors.AddAuthor("Zeeshan", "MZ");

    //コメントの位置

    PointF point = new PointF();

    point.X = 1;

    point.Y = 1;

    //スライド上の著者のためにスライドコメントを追加

    author.Comments.AddComment("Hello Zeeshan, this is slide comment", pres.Slides[0], point, DateTime.Now);

    pres.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 
## **サンプルコードをダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://master.dl.sourceforge.net/project/asposeopenxml/Aspose.Slides%20Vs%20OpenXML/Add%20a%20comment%20to%20a%20slide%20%28Aspose.Slides%29.zip?viasf=1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Add%20a%20comment%20to%20a%20slide%20\(Aspose.Slides\).zip)