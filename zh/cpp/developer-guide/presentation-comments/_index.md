---
title: 演示文稿评论
type: docs
weight: 100
url: /cpp/presentation-comments/
keywords: "评论, PowerPoint 评论, PowerPoint 演示文稿, C++, Aspose.Slides for C++"
description: "在 C++ 中为 PowerPoint 演示文稿添加评论和回复"
---

在 PowerPoint 中，评论以注释或标注的形式出现在幻灯片上。当点击评论时，其内容或消息会被显示出来。

### **为什么要在演示文稿中添加评论？**

您可能希望使用评论在审查演示文稿时提供反馈或与同事沟通。

为了让您在 PowerPoint 演示文稿中使用评论，Aspose.Slides for C++ 提供了

* [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类，其中包含作者集合（来自 [get_CommentAuthors()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac100feeb13ea426b85557a829676227d) 方法）。作者会在幻灯片上添加评论。
* [ICommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment_collection) 接口，它包含个别作者的评论集合。
* [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) 类，包含有关作者及其评论的信息：谁添加了评论，添加评论的时间，评论的位置等。
* [CommentAuthor](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_author) 类，包含有关个别作者的信息：作者的姓名、他的首字母、与作者姓名关联的评论等。

## **添加幻灯片评论**
以下 C++ 代码演示了如何在 PowerPoint 演示文稿的幻灯片中添加评论：

```cpp
// 实例化 Presentation 类
auto presentation = System::MakeObject<Presentation>();
// 添加空白幻灯片
presentation->get_Slides()->AddEmptySlide(presentation->get_LayoutSlides()->idx_get(0));

// 添加作者
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Jawad", u"MF");

// 设置评论的位置
PointF point;
point.set_X(0.2f);
point.set_Y(0.2f);

// 访问 ISlide 1
auto slide1 = presentation->get_Slides()->idx_get(0);
// 访问 ISlide 2
auto slide2 = presentation->get_Slides()->idx_get(1);

// 在幻灯片 1 上为作者添加幻灯片评论
author->get_Comments()->AddComment(u"Hello Jawad, this is slide comment", slide1, point, DateTime::get_Now());

// 在幻灯片 2 上为作者添加幻灯片评论
author->get_Comments()->AddComment(u"Hello Jawad, this is second slide comment", slide2, point, DateTime::get_Now());

// 当传递 null 作为参数时，所有作者的评论都会带入选定的幻灯片
auto comments = slide1->GetSlideComments(author);

// 访问幻灯片 1 的索引 0 的评论
String str = comments[0]->get_Text();

presentation->Save(u"Comments_out.pptx", SaveFormat::Pptx);

if (comments->GetLength(0) > 0)
{
    // 选择索引 0 的作者评论集合
    auto commentCollection = comments[0]->get_Author()->get_Comments();
    String Comment = commentCollection->idx_get(0)->get_Text();
}
```

## **访问幻灯片评论**
以下 C++ 代码演示了如何访问 PowerPoint 演示文稿中幻灯片上现有的评论：

```cpp
// 实例化 Presentation 类
auto presentation = System::MakeObject<Presentation>(u"Comments1.pptx");

for (auto&& commentAuthor : presentation->get_CommentAuthors())
{
    auto author = System::ExplicitCast<CommentAuthor>(commentAuthor);
    for (auto&& comment1 : System::IterateOver(author->get_Comments()))
    {
        SmartPtr<Comment> comment = System::ExplicitCast<Comment>(comment1);
        Console::WriteLine(String(u"ISlide :")
                        + comment->get_Slide()->get_SlideNumber()
                        + u" has comment: " + comment->get_Text()
                        + u" with Author: " + comment->get_Author()->get_Name()
                        + u" posted on time :" + comment->get_CreatedTime() + u"\n");
    }
}
```


## **回复评论**
父评论是在评论或回复的层级结构中的顶部或原始评论。使用 [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) 属性（来自 [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) 接口），您可以设置或获取父评论。

以下 C++ 代码演示了如何添加评论并获取对它们的回复：

```cpp
auto pres = System::MakeObject<Presentation>();

// 访问 ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

// 添加评论
auto author1 = pres->get_CommentAuthors()->AddAuthor(u"Author_1", u"A.A.");
auto comment1 = author1->get_Comments()->AddComment(u"comment1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

// 添加对 comment1 的回复
auto author2 = pres->get_CommentAuthors()->AddAuthor(u"Autror_2", u"B.B.");
auto reply1 = author2->get_Comments()->AddComment(u"reply 1 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply1->set_ParentComment(comment1);

// 添加对 comment1 的另一个回复
auto reply2 = author2->get_Comments()->AddComment(u"reply 2 for comment 1", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply2->set_ParentComment(comment1);

// 添加对现有回复的回复
auto subReply = author1->get_Comments()->AddComment(u"subreply 3 for reply 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
subReply->set_ParentComment(reply2);

auto comment2 = author2->get_Comments()->AddComment(u"comment 2", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
auto comment3 = author2->get_Comments()->AddComment(u"comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());

auto reply3 = author1->get_Comments()->AddComment(u"reply 4 for comment 3", slide1, PointF(10.0f, 10.0f), DateTime::get_Now());
reply3->set_ParentComment(comment3);

// 在控制台上显示评论层级
auto comments = slide1->GetSlideComments(nullptr);
for (int32_t i = 0; i < comments->get_Length(); i++)
{
    auto comment = comments[i];
    while (comment->get_ParentComment() != nullptr)
    {
        Console::Write(u"\t");
        comment = comment->get_ParentComment();
    }

    Console::Write(u"{0} : {1}", comments[i]->get_Author()->get_Name(), comments[i]->get_Text());
    Console::WriteLine();
}

pres->Save(u"parent_comment.pptx", SaveFormat::Pptx);

// 删除 comment1 及其所有回复
comment1->Remove();

pres->Save(u"remove_comment.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="注意" %}} 

* 当使用 [Remove](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#a8bb818ae804d142195c4edcf9012cccb) 方法（来自 [IComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment) 接口）删除评论时，回复该评论的内容也会被删除。 
* 如果 [ParentComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_comment#af3d18815e49ac0eccf38a33cde1ec5e0) 设置导致循环引用，将抛出 [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d)。

{{% /alert %}}

## **添加现代评论**

在 2021 年，微软在 PowerPoint 中引入了*现代评论*。现代评论功能显著提高了 PowerPoint 中的协作。通过现代评论，PowerPoint 用户可以更轻松地解决评论、将评论锚定到对象和文本，并参与互动。

在 [Aspose Slides for C++ 21.11](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-11-release-notes/) 中，我们通过添加 [ModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.modern_comment) 类实现了对现代评论的支持。 [AddModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#a3627fcb3b05cd639fd430bd8248fe66b) 和 [InsertModernComment](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection#ad11c3efb52f3c17f63238447dcc03c94) 方法被添加到 [CommentCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.comment_collection) 类中。

以下 C++ 代码演示了如何在 PowerPoint 演示文稿的幻灯片中添加现代评论：

```cpp
auto pres = System::MakeObject<Presentation>();
// 访问 ISlide 1
auto slide1 = pres->get_Slides()->idx_get(0);

auto newAuthor = pres->get_CommentAuthors()->AddAuthor(u"Some Author", u"SA");
auto modernComment = newAuthor->get_Comments()->AddModernComment(u"This is a modern comment", slide1, nullptr, PointF(100.0f, 100.0f), DateTime::get_Now());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **删除评论**

### **删除所有评论和作者**

以下 C++ 代码演示了如何从演示文稿中删除所有评论和作者：

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// 从演示文稿中删除所有评论
for (auto author : presentation->get_CommentAuthors())
{
    author->get_Comments()->Clear();
}
        
// 删除所有作者
presentation->get_CommentAuthors()->Clear();
presentation->Save(u"example_out.pptx", SaveFormat::Pptx);

```

### **删除特定评论**

以下 C++ 代码演示了如何删除幻灯片上的特定评论：

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
// 添加评论...
auto author = presentation->get_CommentAuthors()->AddAuthor(u"Author", u"A");
author->get_Comments()->AddComment(u"comment 1", slide, PointF(0.2f, 0.2f), System::DateTime::get_Now());
author->get_Comments()->AddComment(u"comment 2", slide, PointF(0.3f, 0.2f), System::DateTime::get_Now());
        
// 移除所有包含 "comment 1" 文本的评论
for (auto commentAuthor : presentation->get_CommentAuthors())
{
    auto toRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IComment>>>();
    for (auto comment : slide->GetSlideComments(commentAuthor))
    {
        if (comment->get_Text() == u"comment 1")
        {
            toRemove->Add(comment);
        }
    }
    for (auto comment : toRemove)
    {
        commentAuthor->get_Comments()->Remove(comment);
    }
}
        
presentation->Save(u"pres.pptx", SaveFormat::Pptx);

```