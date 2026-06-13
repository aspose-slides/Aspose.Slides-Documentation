---
title: टिप्पणी
type: docs
weight: 230
url: /hi/nodejs-java/examples/elements/comment/
keywords:
- कोड उदाहरण
- टिप्पणी
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में स्लाइड टिप्पणियों के साथ काम करें: कोड उदाहरणों के साथ PPT, PPTX, और ODP प्रस्तुतियों में टिप्पणियाँ जोड़ें, उत्तर दें, संपादित करें, समाधान करें और निर्यात करें।"
---
यह लेख **Aspose.Slides for Node.js via Java** का उपयोग करके आधुनिक टिप्पणियों को जोड़ने, पढ़ने, हटाने और उत्तर देने का प्रदर्शन करता है।

## **आधुनिक टिप्पणी जोड़ें**

एक उपयोगकर्ता द्वारा टिप्पणी बनाएँ और प्रस्तुति को सहेजें।

```js
function addModernComment() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let author = presentation.getCommentAuthors().addAuthor("Jhon Smith", "JS");
        let position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100));
        let date = java.newInstanceSync("java.util.Date");

        author.getComments().addModernComment("This is a modern comment", slide, null, position, date);

        presentation.save("modern_comment.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **आधुनिक टिप्पणी तक पहुँचें**

मौजूदा प्रस्तुति से एक आधुनिक टिप्पणी पढ़ें।

```js
function accessModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let author = presentation.getCommentAuthors().get_Item(0);
        let comment = author.getComments().get_Item(0);
        
        console.log("Author: " + author.getName() + ", Comment: " + comment.getText());
    } finally {
        presentation.dispose();
    }
}
```

## **आधुनिक टिप्पणी हटाएँ**

एक टिप्पणी हटाएँ और अद्यतन फ़ाइल को सहेजें।

```js
function removeModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let author = presentation.getCommentAuthors().get_Item(0);

        let comment = author.getComments().get_Item(0);
        comment.remove();

        presentation.save("modern_comment_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **आधुनिक टिप्पणी का उत्तर दें**

एक मूल आधुनिक टिप्पणी पर उत्तर जोड़ें।

```js
function replyToModernComment() {
    let presentation = new aspose.slides.Presentation("modern_comment.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let author = presentation.getCommentAuthors().get_Item(0);
        let comment = author.getComments().get_Item(0);

        let position1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(110), java.newFloat(100));
        let date1 = java.newInstanceSync("java.util.Date");
        let reply1 = author.getComments().addModernComment("Reply 1", slide, null, position1, date1);

        let position2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(120), java.newFloat(100));
        let date2 = java.newInstanceSync("java.util.Date");
        let reply2 = author.getComments().addModernComment("Reply 2", slide, null, position2, date2);

        reply1.setParentComment(comment);
        reply2.setParentComment(comment);

        presentation.save("modern_comment_replies.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```