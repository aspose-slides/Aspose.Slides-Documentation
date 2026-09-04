---
title: 댓글
type: docs
weight: 230
url: /ko/python-java/examples/elements/comment/
keywords:
- 댓글
- 최신 댓글
- 댓글 추가
- 댓글 접근
- 댓글 삭제
- 댓글 회신
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 최신 슬라이드 댓글을 관리합니다: PowerPoint 및 OpenDocument 프레젠테이션에서 댓글을 추가, 읽기, 삭제 및 회신합니다."
---
이 문서는 **Aspose.Slides for Python via Java**를 사용하여 최신 댓글을 추가, 읽기, 삭제 및 회신하는 방법을 보여 줍니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후 API와 필요한 Java 타입을 가져옵니다. 접근 및 삭제 예제는 첫 번째 예제에서 만든 `modern_comment.pptx`를 사용합니다.

## **현대 댓글 추가**

사용자가 작성한 댓글을 만들고 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt.geom import Point2D
from java.util import Date

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("User", "U1")
    position = Point2D.Float(100, 100)
    author.getComments().addModernComment("This is a modern comment", slide, None, position, Date())

    presentation.save("modern_comment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **현대 댓글 접근**

기존 프레젠테이션에서 첫 번째 현대 댓글을 읽습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("modern_comment.pptx")
try:
    if presentation.getCommentAuthors().size() > 0:
        author = presentation.getCommentAuthors().get_Item(0)
        if author.getComments().size() > 0:
            comment = author.getComments().get_Item(0)
            print("Author:", author.getName())
            print("Comment:", comment.getText())
            print("Position:", comment.getPosition())
        else:
            print("The first author has no comments.")
    else:
        print("The presentation has no comment authors.")
finally:
    presentation.dispose()
```

## **현대 댓글 삭제**

첫 번째 댓글을 삭제하고 업데이트된 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("modern_comment.pptx")
try:
    if presentation.getCommentAuthors().size() > 0:
        author = presentation.getCommentAuthors().get_Item(0)
        if author.getComments().size() > 0:
            comment = author.getComments().get_Item(0)
            comment.remove()
        else:
            print("The first author has no comments.")
    else:
        print("The presentation has no comment authors.")

    presentation.save("modern_comment_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **현대 댓글 회신**

부모 댓글을 만든 뒤 두 개의 회신을 추가하고 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt.geom import Point2D
from java.util import Date

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    author = presentation.getCommentAuthors().addAuthor("User", "U1")
    created_time = Date()

    parent_position = Point2D.Float(100, 100)
    parent_comment = author.getComments().addModernComment("Parent comment", slide, None, parent_position, created_time)

    reply1_position = Point2D.Float(110, 100)
    reply1 = author.getComments().addModernComment("Reply 1", slide, None, reply1_position, created_time)

    reply2_position = Point2D.Float(120, 100)
    reply2 = author.getComments().addModernComment("Reply 2", slide, None, reply2_position, created_time)

    reply1.setParentComment(parent_comment)
    reply2.setParentComment(parent_comment)

    presentation.save("modern_comment_replies.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```