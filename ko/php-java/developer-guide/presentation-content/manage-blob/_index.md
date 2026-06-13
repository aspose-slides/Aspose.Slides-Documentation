---
title: PHP에서 프레젠테이션 BLOB을 관리하여 효율적인 메모리 사용
linktitle: BLOB 관리
type: docs
weight: 10
url: /ko/php-java/manage-blob/
keywords:
- 대형 객체
- 대형 항목
- 대형 파일
- BLOB 추가
- BLOB 내보내기
- 이미지를 BLOB으로 추가
- 메모리 감소
- 메모리 사용량
- 대형 프레젠테이션
- 임시 파일
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides의 BLOB 데이터를 관리하여 PowerPoint 및 OpenDocument 파일 작업을 간소화하고 효율적인 프레젠테이션 처리를 실현합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 대용량 이진 데이터를 BLOB 기반으로 처리하여 큰 이미지, 오디오, 비디오 및 프레젠테이션 파일 작업 시 메모리 사용량을 줄이는 데 도움을 줍니다.

이 문서에서는 BLOB 기반 처리를 사용하여 프레젠테이션에 대용량 미디어를 추가하고, 프레젠테이션에서 대용량 미디어를 내보내며, 대용량 프레젠테이션을 보다 효율적으로 로드하는 방법을 보여줍니다. 또한 처리 중에 임시 파일을 사용하는 방법과 임시 파일이 저장되는 폴더를 변경하는 방법도 설명합니다.

## **BLOB에 대하여**

**BLOB** (**Binary Large Object**)는 일반적으로 바이너리 형식으로 저장된 대용량 항목(사진, 프레젠테이션, 문서 또는 미디어)입니다.  

Aspose.Slides for PHP via Java는 대용량 파일이 포함된 경우 메모리 사용량을 줄이는 방식으로 객체에 BLOB을 사용할 수 있게 합니다.

{{% alert title="정보" color="info" %}}
스트림과 상호 작용할 때 특정 제한을 피하기 위해 Aspose.Slides는 스트림의 내용을 복사할 수 있습니다. 스트림을 통해 대용량 프레젠테이션을 로드하면 프레젠테이션 내용이 복사되어 로딩 속도가 느려집니다. 따라서 대용량 프레젠테이션을 로드하려는 경우 스트림이 아닌 프레젠테이션 파일 경로를 사용하는 것을 강력히 권장합니다.
{{% /alert %}}

## **메모리 사용량을 줄이기 위해 BLOB 사용**

### **BLOB을 통해 대용량 파일을 프레젠테이션에 추가**

[Aspose.Slides](/slides/ko/php-java/) for Java는 메모리 사용량을 줄이기 위해 BLOB을 포함한 프로세스를 통해 대용량 파일(예: 큰 비디오 파일)을 프레젠테이션에 추가할 수 있게 합니다.

이 Java 예제는 BLOB 프로세스를 사용하여 큰 비디오 파일을 프레젠테이션에 추가하는 방법을 보여줍니다:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # 비디오가 추가될 새로운 프레젠테이션을 생성합니다
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # 프레젠테이션에 비디오를 추가합니다 - 우리는 KeepLocked 동작을 선택했는데, 이는
      # "veryLargeVideo.avi" 파일에 접근할 의도가 없기 때문입니다.
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # 프레젠테이션을 저장합니다. 큰 프레젠테이션이 출력되는 동안에도 메모리 사용량은
      # pres 객체의 전체 수명 동안 낮게 유지됩니다
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **BLOB을 통해 프레젠테이션에서 대용량 파일 내보내기**

Aspose.Slides for PHP via Java는 BLOB을 포함한 프로세스를 통해 프레젠테이션에서 대용량 파일(예: 오디오 또는 비디오 파일)을 내보낼 수 있게 합니다. 예를 들어, 큰 미디어 파일을 프레젠테이션에서 추출해야 하지만 파일을 메모리에 로드하고 싶지 않을 때 BLOB 프로세스를 사용하면 메모리 사용량을 낮게 유지할 수 있습니다.

이 코드는 위에서 설명한 작업을 시연합니다:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # 소스 파일을 잠그고 메모리로 로드하지 않습니다
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Presentation 인스턴스를 생성하고 "hugePresentationWithAudiosAndVideos.pptx" 파일을 잠급니다.
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # 각 비디오를 파일로 저장합니다. 높은 메모리 사용을 방지하기 위해 필요한 버퍼를 사용합니다
    # 프레젠테이션 비디오 스트림의 데이터를 새로 만든 비디오 파일 스트림으로 전송합니다.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # 비디오들을 순회합니다
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # 프레젠테이션 비디오 스트림을 엽니다. 의도적으로 다음 속성에 접근하지 않았음을 참고하십시오
      # video.BinaryData와 같은 속성 - 이 속성은 전체 비디오를 포함하는 바이트 배열을 반환하므로
      # 메모리로 바이트를 로드합니다. 우리는 video.GetStream을 사용하며, 이는 Stream을 반환하고 메모리 로드를 하지 않습니다
      # 전체 비디오를 메모리에 로드할 필요가 없습니다.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # 비디오 또는 프레젠테이션 크기에 관계없이 메모리 사용량은 낮게 유지됩니다.
    }
    # 필요하면 오디오 파일에도 동일한 단계를 적용할 수 있습니다.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **이미지를 BLOB으로 프레젠테이션에 추가**

[ImageCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/imagecollection/) 클래스의 메서드를 사용하면 스트림으로 큰 이미지를 추가하여 BLOB으로 처리할 수 있습니다.

이 PHP 코드는 BLOB 프로세스를 사용하여 큰 이미지를 추가하는 방법을 보여줍니다:

```php
  $pathToLargeImage = "large_image.jpg";
  # 이미지를 추가할 새로운 프레젠테이션을 생성합니다.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # 이미지를 프레젠테이션에 추가합니다 - KeepLocked 동작을 선택했는데, 우리는
      # "largeImage.png" 파일에 접근하려는 의도가 없습니다.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # 프레젠테이션을 저장합니다. 큰 프레젠테이션이 출력되는 동안에도 메모리 사용량은
      # pres 객체의 전체 수명 주기 동안 낮게 유지됩니다.
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **메모리와 대용량 프레젠테이션**

일반적으로 대용량 프레젠테이션을 로드하려면 컴퓨터에 많은 임시 메모리가 필요합니다. 프레젠테이션의 모든 내용이 메모리로 로드되고, 로드된 파일은 더 이상 사용되지 않습니다.

예를 들어 1.5 GB 비디오 파일을 포함한 대용량 PowerPoint 프레젠테이션(large.pptx)을 생각해 보십시오. 이 프레젠테이션을 로드하는 표준 방법은 다음 PHP 코드에 설명되어 있습니다:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

하지만 이 방법은 약 1.6 GB의 임시 메모리를 소모합니다.

### **BLOB으로 대용량 프레젠테이션 로드**

BLOB을 포함한 프로세스를 사용하면 적은 메모리로 대용량 프레젠테이션을 로드할 수 있습니다. 다음 PHP 코드는 BLOB 프로세스를 사용하여 large.pptx 파일을 로드하는 구현을 설명합니다:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **임시 파일 폴더 변경**

BLOB 프로세스를 사용하면 기본 임시 파일 폴더에 임시 파일이 생성됩니다. 임시 파일을 다른 폴더에 저장하고 싶다면 `setTempFilesRootPath`를 사용하여 저장 위치를 변경할 수 있습니다:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="정보" color="info" %}}
`setTempFilesRootPath`를 사용할 경우 Aspose.Slides가 임시 파일을 저장할 폴더를 자동으로 만들지 않습니다. 폴더를 직접 생성해야 합니다.
{{% /alert %}}

### **Presentation 객체 해제하여 메모리 해제**

대용량 프레젠테이션을 처리할 때는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 인스턴스를 적절히 해제하여 점유한 메모리를 해제해야 합니다. 프레젠테이션 사용을 마친 후 `dispose()`를 호출하여 관리되지 않는 리소스를 해제하십시오.

```php
$presentation = new Presentation("large.pptx");

# ...프레젠테이션을 처리합니다...
$presentation->save("large.pdf", SaveFormat::Pdf);

# 명시적으로 리소스를 해제합니다.
$presentation->dispose();
```

## **FAQ**

**Aspose.Slides 프레젠테이션에서 어떤 데이터가 BLOB으로 처리되며 BLOB 옵션에 의해 제어됩니까?**

이미지, 오디오, 비디오와 같은 대용량 이진 객체가 BLOB으로 처리됩니다. 전체 프레젠테이션 파일 자체도 로드하거나 저장할 때 BLOB 처리를 포함합니다. 이러한 객체는 메모리 사용량을 관리하고 필요에 따라 임시 파일로 스필하도록 하는 BLOB 정책에 의해 제어됩니다.

**프레젠테이션 로드 중에 BLOB 처리 규칙을 어디에서 구성합니까?**

[LoadOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/loadoptions/)와 [BlobManagementOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/blobmanagementoptions/)를 사용합니다. 여기서 메모리 내 BLOB 용량 제한, 임시 파일 허용 여부, 임시 파일 루트 경로, 소스 잠금 동작 등을 설정합니다.

**BLOB 설정이 성능에 영향을 주나요? 속도와 메모리 사용량의 균형을 어떻게 맞추나요?**

예, BLOB을 메모리에 유지하면 속도가 최대화되지만 RAM 사용량이 증가합니다. 메모리 제한을 낮추면 작업이 더 많이 임시 파일로 전환되어 RAM 사용량은 감소하지만 추가 I/O가 발생합니다. 작업 부하와 환경에 맞는 적절한 균형을 맞추려면 [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ko/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) 메서드를 사용하십시오.

**극도로 큰 프레젠테이션(예: 기가바이트 단위)을 열 때 BLOB 옵션이 도움이 됩니까?**

예. [BlobManagementOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/blobmanagementoptions/)는 이러한 시나리오에 맞춰 설계되었습니다. 임시 파일을 활성화하고 소스 잠금을 사용하면 피크 RAM 사용량을 크게 줄이고 매우 큰 파일의 처리를 안정화할 수 있습니다.

**스트림에서 로드할 때도 BLOB 정책을 사용할 수 있습니까?**

예. 동일한 규칙이 스트림에도 적용됩니다. 프레젠테이션 인스턴스는 선택된 잠금 모드에 따라 입력 스트림을 소유하고 잠글 수 있으며, 허용되는 경우 임시 파일이 사용되어 처리 중 메모리 사용량을 예측 가능하게 유지합니다.